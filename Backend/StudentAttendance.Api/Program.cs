using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StudentAttendance.Api;
using StudentAttendance.Api.Configuration;
using StudentAttendance.Api.Middlewares;
using StudentAttendance.Core;
using StudentAttendance.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCore().AddData();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<ApiMappingProfile>();
    cfg.AddProfile<DataMappingProfile>();
});

builder.Services.AddCors();

builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("SecretSettings"));

builder.Services.AddDbContext<StudentAttendanceDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["SecretSettings:StudentAttendanceDbContext"]);
});
var key = Encoding.ASCII.GetBytes(builder.Configuration["SecretSettings:Secret"]);
var tokenValidationParams = new TokenValidationParameters
{
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(key),
    ValidateIssuer = false,
    ValidateAudience = false,
    ValidateLifetime = true,
    RequireExpirationTime = false,
    ClockSkew = TimeSpan.Zero
};

builder.Services.AddSingleton(tokenValidationParams);

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(jwt =>
    {
        jwt.SaveToken = true;
        jwt.TokenValidationParameters = tokenValidationParams;
    });


builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options
        .SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<StudentAttendanceDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(b => b.WithOrigins("http://localhost:4200"));

app.UseValidationException();

app.MapControllers();

app.Run();
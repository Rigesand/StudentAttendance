using Microsoft.EntityFrameworkCore;
using StudentAttendance.Api;
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


builder.Services.AddDbContext<StudentAttendanceDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["SecretSettings:StudentAttendanceDbContext"]);
});

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
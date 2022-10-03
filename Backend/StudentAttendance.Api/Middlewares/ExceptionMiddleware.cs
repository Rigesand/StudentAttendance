using System.ComponentModel.DataAnnotations;

namespace StudentAttendance.Api.Middlewares;

public static class ExceptionMiddleware
{
    public static void UseValidationException(this IApplicationBuilder app)
    {
        app.Use(async (context, next) =>
        {
            try
            {
                await next(context);
            }
            catch (ValidationException ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(new {ex.Message});
            }
        });
    }
}
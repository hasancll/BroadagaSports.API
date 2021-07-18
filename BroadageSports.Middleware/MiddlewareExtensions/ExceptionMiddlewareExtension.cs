using BroadageSports.Middleware.MiddleWares;
using Microsoft.AspNetCore.Builder;

namespace BroadageSports.Middleware.MiddlewareExtensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static void UseExceptionMiddleWare(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}

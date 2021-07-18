using BroadageSports.Middleware.MiddleWares;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageSports.Middleware.MiddlewareExtensions
{
    public static class ResponseWrapperMiddlewareExtension
    {
        public static void UseResponseWrapperMiddleware(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<ResponseWrapperMiddleware>();
        }
    }
}

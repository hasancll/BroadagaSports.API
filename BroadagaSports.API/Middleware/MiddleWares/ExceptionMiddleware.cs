using BroadagaSports.API.Logging.Abstract;
using BroadagaSports.API.Logging.Concrate;
using BroadageSports.Exceptions;
using BroadageSports.Middleware.BroadageSportsResponseHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadagaSports.API.Middleware.MiddleWares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.ContentType = "application/json";
            var logger=httpContext.RequestServices.GetRequiredService<IMatchLogger>();
            try
            {
                await _next(httpContext).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                String errorMessage = ex.Message;

                if (ex is BroadageApiExceptions)
                {
                    errorMessage = ex.Message;
                }

                var response = BroadageSportsResponse.GetBroadagaSportsResponseModel(false, "400", errorMessage);

                httpContext.Response.StatusCode = StatusCodes.Status200OK;
                httpContext.Response.ContentType = "application/json";
                logger.Error(errorMessage);
                await httpContext.Response.WriteAsync(response).ConfigureAwait(false);
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace TestNware.Helpers
{
    public class CorsMiddleware
    {
        private readonly RequestDelegate _next;

        public CorsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            CorsExtension.LiberarCorsDomain(httpContext.Response);
            httpContext.Response.StatusCode = (int)HttpStatusCode.OK;

            if (httpContext.Request.Method.Equals("OPTIONS", StringComparison.CurrentCultureIgnoreCase))
            {
                return Task.FromResult(0);
            }

            return _next(httpContext);
        }
    }
}

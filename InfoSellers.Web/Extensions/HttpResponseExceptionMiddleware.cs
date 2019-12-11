using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoSellers.Model.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace InfoSellers.Web.Extensions
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class HttpResponseExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public HttpResponseExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (HttpResponseException ex) 
            {

                httpContext.Response.Clear();
                httpContext.Response.StatusCode = ex.StatusCode;
                httpContext.Response.ContentType = ex.ContentType;

                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(ex.Message));

                return;
            }

            
        }

        
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class HttpResponseExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseHttpResponseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HttpResponseExceptionMiddleware>();
        }
    }
}

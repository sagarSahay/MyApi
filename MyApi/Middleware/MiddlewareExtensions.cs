using System;
using Microsoft.AspNetCore.Builder;

namespace MyApi.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLog(this IApplicationBuilder builder)
        => builder.UseMiddleware<RequestLogMiddleware>();

        public static IApplicationBuilder UseHeaderValidation(this IApplicationBuilder builder)
        => builder.UseMiddleware<HeaderValidationMiddleware>();
    }
}

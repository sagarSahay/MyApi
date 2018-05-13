using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MyApi.Middleware
{
    public class RequestLogMiddleware
    {
        private RequestDelegate next;
        private ILogger<RequestLogMiddleware> logger;

        public RequestLogMiddleware(RequestDelegate next, ILogger<RequestLogMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            logger.LogInformation($"requesting path: {context.Request.Path}");
            await next(context);
        }
    }
}

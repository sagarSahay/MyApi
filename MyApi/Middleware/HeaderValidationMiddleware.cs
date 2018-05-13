using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MyApi.Middleware
{
    public class HeaderValidationMiddleware
    {
        private RequestDelegate next;
        private ILogger logger;

        public HeaderValidationMiddleware(RequestDelegate next, ILogger<HeaderValidationMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            logger.LogInformation("Validating HTTP headers...");
            if(context.Request.Headers.Any(x=> x.Key == "test"))
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var json = JsonConvert.SerializeObject(new { message = "Invalid Header" });
                await context.Response.WriteAsync(json);
                return;
            }
            await next(context);
        }
    }
}

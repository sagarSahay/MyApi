using System;
using Microsoft.AspNetCore.Http;

namespace MyApi.Middleware
{
    public class RequestLogMiddlewar
    {
        public RequestLogMiddlewar(RequestDelegate next)
        {
        }
    }
}

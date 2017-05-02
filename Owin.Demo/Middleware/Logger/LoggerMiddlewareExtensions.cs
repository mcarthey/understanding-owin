using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin.Demo.Middleware;

// Changed namespace from default of Owin.Demo.Middleware to just Owin to make this easier to find
namespace Owin
{
    public static class LoggerMiddlewareExtensions
    {
        public static IAppBuilder UseLoggerMiddleware(this IAppBuilder app, LoggerMiddlewareOptions options)
        {
            return app.Use<LoggerMiddleware>(options);
        }
    }
}
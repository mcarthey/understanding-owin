using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin.Demo.Middleware;

// Changed namespace from default of Owin.Demo.Middleware to just Owin to make this easier to find
namespace Owin
{
    public static class ElmMiddlewareExtensions
    {
        public static IAppBuilder UseElmMiddleware(this IAppBuilder app, ElmMiddlewareOptions options)
        {
            return app.Use<ElmMiddleware>(options);
        }
    }
}
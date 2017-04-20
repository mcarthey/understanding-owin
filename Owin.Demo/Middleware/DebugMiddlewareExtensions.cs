using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin.Demo.Middleware;

// Changed namespace from default of Owin.Demo.Middleware to just Owin to make this easier to find
namespace Owin
{
    public static class DebugMiddlewareExtensions
    {
        public static void UseDebugMiddleware(this IAppBuilder app, DebugMiddlewareOptions options = null)
        {
            if (options == null)
            {
                options = new DebugMiddlewareOptions();
            }
            app.Use<DebugMiddleware>(options);
        }
    }
}
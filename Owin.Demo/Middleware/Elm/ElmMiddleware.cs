using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin;
// prevents need to constantly write it out
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string,object>, System.Threading.Tasks.Task>;

namespace Owin.Demo.Middleware
{
    public class ElmMiddleware 
    {
        private AppFunc _next;
        private ElmMiddlewareOptions _options;

        public ElmMiddleware(AppFunc next, ElmMiddlewareOptions options)
        {
            _next = next;
            _options = options;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            // do request ...

            await _next(environment);

            // do response ... 
        }
    }
}
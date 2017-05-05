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
    public class ExceptionMiddleware 
    {
        private AppFunc _next;
        private ExceptionMiddlewareOptions _options;

        public ExceptionMiddleware(AppFunc next, ExceptionMiddlewareOptions options)
        {
            _next = next;
            _options = options;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            foreach (var key in _options.RequestKeys)
            {
                _options.Log(key, environment[key]);
            }

            await _next(environment);

            foreach (var key in _options.ResponseKeys)
            {
                _options.Log(key, environment[key]);
            }
        }
    }
}
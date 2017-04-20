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
    public class DebugMiddleware  // : OwinMiddleware (katana specific so don't use)
    {
        private AppFunc _next;
        private DebugMiddlewareOptions _options;

        /// <summary>
        /// Constructor for Owin pipeline to track next middleware in the pipeline
        /// </summary>
        /// <param name="next">Reference to next middleware in the pipeline</param>
        /// <remarks>
        /// This existed prior to addition of DebugMiddlewareOptions
        /// </remarks>
        //public DebugMiddleware(AppFunc next)
        //{
        //    _next = next;
        //}

        /// <summary>
        /// Constructor for Owin pipeline which allows for settings of options
        /// </summary>
        /// <param name="next"></param>
        /// <param name="options">Allows for configuration changes based upon specific scenarios</param>
        public DebugMiddleware(AppFunc next, DebugMiddlewareOptions options)
        {
            _next = next;
            _options = options;

            if (_options.OnIncomingRequest == null)
            {
                _options.OnIncomingRequest = context => { Debug.WriteLine("Incoming Request: " + context.Request.Path); };
            }
            if (_options.OnOutgoingRequest == null)
            {
                _options.OnOutgoingRequest = context => { Debug.WriteLine("Outgoing Request: " + context.Request.Path); };
            }
        }


        /// <summary>
        /// Method to invoke the middleware
        /// </summary>
        /// <param name="environment">Contains passed in HTTP request and functionality</param>
        /// <returns>Task marked as 'async' to avoid having to manually take care of returning a task</returns>
        public async Task Invoke(IDictionary<string, object> environment)
        {
            // convert environment dictionary into context
            //var path = (string)environment["owin.RequestPath"];
            var context = new OwinContext(environment);

            //Debug.WriteLine("Incoming Request: " + context.Request.Path); // moved after creation of DebugMiddlewareOptions
            _options.OnIncomingRequest(context);
            await _next(environment);
            _options.OnOutgoingRequest(context);
            //Debug.WriteLine("Outgoing Request: " + context.Request.Path); // moved after creation of DebugMiddlewareOptions

        }
    }
}
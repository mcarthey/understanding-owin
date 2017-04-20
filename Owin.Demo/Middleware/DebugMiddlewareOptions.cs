using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;

namespace Owin.Demo.Middleware
{
    /// <summary>
    /// Configure middleware to do different things in different situations
    /// </summary>
    /// <remarks>Class is named as the middleware with 'Options' at the end </remarks>
    public class DebugMiddlewareOptions
    {
        public Action<IOwinContext> OnIncomingRequest { get; set; }
        public Action<IOwinContext> OnOutgoingRequest { get; set; }
    }
}
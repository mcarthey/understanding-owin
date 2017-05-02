using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;

namespace Owin.Demo.Middleware
{
    public class LoggerMiddlewareOptions
    {
        public IList<string> RequestKeys { get; set; }
        public IList<string> ResponseKeys { get; set; }
        public Action<string, object> Log { get; set; }
    }
}
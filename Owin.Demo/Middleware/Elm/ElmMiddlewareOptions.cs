using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Diagnostics.Elm;
using Microsoft.Owin;
using Microsoft.Extensions.Logging;

namespace Owin.Demo.Middleware
{
    public class ElmMiddlewareOptions
    {
        public List<ElmOptions> ElmOptions { get; set; }
    }
}
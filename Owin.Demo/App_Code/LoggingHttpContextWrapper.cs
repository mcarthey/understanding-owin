using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Owin.Demo
{
    public interface ILoggingHttpContextWrapper
    {
        HttpContextWrapper HttpContextWrapper { get; }
    }

    public class LoggingHttpContextWrapper : ILoggingHttpContextWrapper
    {
        public LoggingHttpContextWrapper()
        {
            HttpContextWrapper = new HttpContextWrapper(HttpContext.Current);
        }

        public HttpContextWrapper HttpContextWrapper { get; private set; }
    }
}
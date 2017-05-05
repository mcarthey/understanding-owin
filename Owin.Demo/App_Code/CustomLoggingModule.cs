using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Owin.Demo
{
    public class CustomLoggingModule : IHttpModule
    {
        public ILogService LogService { get; set; }
        public Func<ILoggingHttpContextWrapper> LogginHttpContextWrapperDelegate { get; set; }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += BeginRequest;
            context.EndRequest += EndRequest;
        }

        public CustomLoggingModule()
        {
            LogginHttpContextWrapperDelegate = () => new LoggingHttpContextWrapper();
        }

        public void BeginRequest(object sender, EventArgs eventArgs)
        {
            LogService.LogInfo(LogginHttpContextWrapperDelegate().HttpContextWrapper);
        }

        public void EndRequest(object sender, EventArgs eventArgs)
        {
            //some
        }

        public void Dispose() { }
    }
}
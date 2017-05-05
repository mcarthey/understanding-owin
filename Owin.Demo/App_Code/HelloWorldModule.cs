using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.ExtraInformation;

namespace Owin.Demo
{
    public class HelloWorldModule : IHttpModule
    {
        public HelloWorldModule()
        {
        }

        public String ModuleName
        {
            get { return "HelloWorldModule"; }
        }

        // In the Init function, register for HttpApplication 
        // events by adding your handlers.
        public void Init(HttpApplication application)
        {
            application.BeginRequest += (new EventHandler(this.Application_BeginRequest));
            application.EndRequest += (new EventHandler(this.Application_EndRequest));
            application.Error += Application_Error;
        }

        private void Application_Error(object sender, EventArgs e)
        {
            HttpContext ctx = HttpContext.Current;
            HttpRequest request = ctx.Request;
            HttpApplication application = (HttpApplication)sender;
            Exception ex = application.Server.GetLastError().GetBaseException();

            // Use log write factory to load from app.config
            LogWriterFactory logWriterFactory = new LogWriterFactory();

            // Create the LogWrite instance
            LogWriter logWriter = logWriterFactory.Create();

            // Create debug provider
            var extendedInfo = new Dictionary<string, object>();
            var debug = new DebugInformationProvider();
            debug.PopulateDictionary(extendedInfo);

            // Create the Log Entry
            var logEntry = new LogEntry
            {
                Message = "This is an error message",
                Categories = new List<string> { "Debug" },
                ExtendedProperties = extendedInfo
            };

            // Prepare the trace manager
            TraceManager traceManager = new TraceManager(logWriter);

            // Log
            // checking app.config "tracingEnabled" - <loggingConfiguration name="" tracingEnabled="true">
            if (logWriter.IsLoggingEnabled())
            {
                logWriter.Write("This is a Demo log message", "Demo");
                logWriter.Write("This is an application error", "Error");
                logWriter.Write("This is a general log message");

                using (traceManager.StartTrace("Debug"))
                {
                    logWriter.Write(logEntry);
                }
            }

            ExceptionPolicy.HandleException(ex, "GlobalExceptionLogger");
            ctx.Server.ClearError();

            ctx.Response.Write(Logger.IsLoggingEnabled());
            ctx.Response.Write(Logger.ShouldLog(logEntry));
            ctx.Response.Write(logEntry.Categories.Contains("Debug"));
        }

        private void Application_BeginRequest(Object source,
             EventArgs e)
        {
            // Create HttpApplication and HttpContext objects to access
            // request and response properties.
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;
            context.Response.Write("<h1><font color=red>HelloWorldModule: Beginning of Request</font></h1><hr>");
        }

        private void Application_EndRequest(Object source, EventArgs e)
        {
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;
            context.Response.Write("<hr><h1><font color=red>HelloWorldModule: End of Request</font></h1>");
        }

        public void Dispose()
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Owin.Demo
{
    public interface ILogService
    {
        void LogInfo(HttpContextWrapper httpContextWrapper);
    }

    public class LogService : ILogService
    {
        public void LogInfo(HttpContextWrapper httpContextWrapper)
        {
            // Real logger implementation

            //HttpContext ctx = HttpContext.Current;
            //HttpRequest request = ctx.Request;
            //HttpApplication application = (HttpApplication)sender;
            //Exception ex = application.Server.GetLastError().GetBaseException();

            //// Use log write factory to load from app.config
            //LogWriterFactory logWriterFactory = new LogWriterFactory();

            //// Create the LogWrite instance
            //LogWriter logWriter = logWriterFactory.Create();

            //// Create debug provider
            //var extendedInfo = new Dictionary<string, object>();
            //var debug = new DebugInformationProvider();
            //debug.PopulateDictionary(extendedInfo);

            //// Create the Log Entry
            //var logEntry = new LogEntry
            //{
            //    Message = "This is an error message",
            //    Categories = new List<string> { "Debug" },
            //    ExtendedProperties = extendedInfo
            //};

            //// Prepare the trace manager
            //TraceManager traceManager = new TraceManager(logWriter);

            //// Log
            //// checking app.config "tracingEnabled" - <loggingConfiguration name="" tracingEnabled="true">
            //if (logWriter.IsLoggingEnabled())
            //{
            //    logWriter.Write("This is a Demo log message", "Demo");
            //    logWriter.Write("This is an application error", "Error");
            //    logWriter.Write("This is a general log message");

            //    using (traceManager.StartTrace("Debug"))
            //    {
            //        logWriter.Write(logEntry);
            //    }
            //}

            //ExceptionPolicy.HandleException(ex, "GlobalExceptionLogger");
            //ctx.Server.ClearError();

            //ctx.Response.Write(Logger.IsLoggingEnabled());
            //ctx.Response.Write(Logger.ShouldLog(logEntry));
            //ctx.Response.Write(logEntry.Categories.Contains("Debug"));
        }
    }
}
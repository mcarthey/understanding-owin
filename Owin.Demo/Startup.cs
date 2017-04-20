﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin.Demo.Middleware;

namespace Owin.Demo
{
    public class Startup
    {
        /// <summary>
        /// Project Katana entry point into the application.  Inserts a middleware into the Owin pipeline.
        /// It is provided via the Microsoft.Owin package.
        /// </summary>
        /// <remarks>
        /// This entry point needs to be in the root namespace of the application.  You can name this anything but 
        /// it would need to be specified via an attribute or a setting in the Web.config
        /// </remarks>
        /// <param name="app">Used to add middleware to the Owin pipeline</param>
        public static void Configuration(IAppBuilder app)
        {
            // Creating multiple middlewares
            // Note both are performing the same function but using different syntaxes

            // 1. Debugging middleware to track incoming requests and outgoing responses
            //            app.Use(async delegate (IOwinContext context, Func<Task> func)
            //            {
            //                Debug.WriteLine("Incoming Request: " + context.Request.Path);

            // make sure the rest of the pipeline executes before doing another Debug.WriteLine
            // the 'func' delegate references the next middleware in the pipeline (our 'Hello World')
            // - note because our next delegate is async we need to use await
            //                await func();
            // after the 'await func' the response headers have already been sent
            //                Debug.WriteLine("Outgoing Request: " + context.Request.Path);
            //            });

            // REPLACED ABOVE AFTER THE DebugMiddleware WAS CREATED
            // register the DebugMiddleware into the pipeline - would need to have the default constructor available prior to addition of options
            //app.Use<DebugMiddleware>();
            //app.Use<DebugMiddleware>(new DebugMiddlewareOptions());

            // Addition of functionality to override the default behavior for DebugMiddlewareOptions setup in the DebugMiddleware
            // Note this app.Use<DebugMiddleware> syntax is not conventional.  Typically people write app.UseXXXXX (eg. app.UseDebug())
            // - this was enabled by addition of the DebugMiddlewareExtensions class
            //app.Use<DebugMiddleware>(new DebugMiddlewareOptions
            app.UseDebugMiddleware(new DebugMiddlewareOptions
            {
                // Inject performance/stopwatch into middleware http request (environment dictionary)
                OnIncomingRequest = context =>
                {
                    var watch = new Stopwatch();
                    watch.Start();
                    context.Environment["DebugStopwatch"] = watch;
                },
                OnOutgoingRequest = context =>
                {
                    var watch = (Stopwatch)context.Environment["DebugStopwatch"];
                    watch.Stop();
                    Debug.WriteLine("Request took: " + watch.ElapsedMilliseconds + " ms");
                }
            });

            // 2. Insert 'Hello World' into the response stream
            app.Use(async (ctx, next) =>
            {
                // want to do asyncronous work so added 'async' keyword to delegate
                // added 'await' so delegate doesn't return before the write is complete
                // ctx.Response provides access to key "owin.ResponseBody" 
                // - could otherwise cast the object coming out of the dictionary using the 'magic string'
                // ctx.Environment["owin.ResponseBody"]
                await ctx.Response.WriteAsync("<html><head></head><body>Hello World</body></html>");
            });

        }
    }
}
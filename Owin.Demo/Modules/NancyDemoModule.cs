﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.Owin;
using Nancy.Security;

namespace Owin.Demo.Modules
{
    public class NancyDemoModule : NancyModule
    {
        public NancyDemoModule()
        {
            // ensure the user is authenticated before using this module
            this.RequiresMSOwinAuthentication();

            // RouteBuilder
            // Register first path to handle - Dictionary exists for each of the HTTP verbs in Nancy
            // Delegate will be called each time there is a Get request for the listed path
            // Anything in the delegate will be returned back to the client
            Get["/nancy"] = x =>
            {
                var env = Context.GetOwinEnvironment();
                var user = Context.GetMSOwinUser();
                return "Hello from Nancy!  You requested: " + env["owin.RequestPathBase"] + env["owin.RequestPath"] 
                    + "<br/><br/>User:" + user.Identity.Name;


            };
        }
    }
}
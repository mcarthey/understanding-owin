using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Owin.Demo.Hosting
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
//#if DEBUG
//            app.UseErrorPage();
//#endif
//            app.UseWelcomePage("/");
            app.UseStaticFiles();

            // when serving up static content you need to manage when self-hosting

            // create a simple pipeline
            app.Use(async (ctx, next) =>
            {
                await ctx.Response.WriteAsync("Hello world");
            });
        }
    }
}

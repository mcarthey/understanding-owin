using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Owin.Demo.Hosting;

namespace Owin.Demo.Tests
{
    [TestClass]
    public class OwinTests
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks>Need to install Microsoft.Owin.Testing</remarks>
        [TestMethod]
        public async Task Owin_returns_200_on_request_to_root()
        {
            // created the code below and commented out the similar after creation of the private method
            var statusCode = await CallServer(async x =>
            {
                var response = await x.GetAsync("/");
                return response.StatusCode;
            });
            Assert.AreEqual(HttpStatusCode.OK, statusCode);

            //using (var server = TestServer.Create<Startup>())
            //{
            //    var response = await server.HttpClient.GetAsync("/");
            //    // TODO: Validate response
            //    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            //}
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks>Need to install Microsoft.Owin.Testing</remarks>
        [TestMethod]
        public async Task Owin_returns_hello_world_on_request_to_root()
        {
            // created the code below and commented out the similar after creation of the private method
            var body = await CallServer(async x =>
            {
                var response = await x.GetAsync("/");
                return await response.Content.ReadAsStringAsync();
            });
            Assert.AreEqual("Hello world", body);

            //using (var server = TestServer.Create<Startup>())
            //{
            //    var response = await server.HttpClient.GetAsync("/");
            //    var body = await response.Content.ReadAsStringAsync();
            //    // TODO: Validate response
            //    Assert.AreEqual("Hello world", body);
            //}
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks>Need to install Microsoft.Owin.Testing</remarks>
        [TestMethod]
        public async Task Owin_returns_correct_contenttype_on_request_to_gif()
        {
            // created the code below and commented out the similar after creation of the private method
            var contenttype = await CallServer(async x =>
            {
                var response = await x.GetAsync("/images/dilbert.gif");
                return response.Content.Headers.ContentType.MediaType;
            });
            Assert.AreEqual("image/gif", contenttype);

            //using (var server = TestServer.Create<Startup>())
            //{
            //    var response = await server.HttpClient.GetAsync("/images/dilbert.gif");
            //    var contenttype = response.Content.Headers.ContentType.MediaType;
            //    // TODO: Validate response
            //    Assert.AreEqual("image/gif", contenttype);
            //}
        }
        private async Task<T> CallServer<T>(Func<HttpClient, Task<T>> callback)
        {
            using (var server = TestServer.Create<Startup>())
            {
                return await callback(server.HttpClient);
            }
        }
    }
}

﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Owin.Demo;

namespace Owin.Tests
{
    /// <summary>
    /// Summary description for UnitTest
    /// </summary>
    [TestClass]
    public class UnitTest
    {
        public UnitTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CustomLoggingModule_BeginRequest_VerifyLogInfoMethodIsCalled()
        {
            var sut = new CustomLoggingModule();
            var loggerServiceMock = new MockLoggerService();
            var loggingHttpContextWrapperStub = new StubLoggingHttpContextWrapper();

            sut.LogService = loggerServiceMock;
            sut.LogginHttpContextWrapperDelegate = () => loggingHttpContextWrapperStub;

            sut.BeginRequest(new object(), new EventArgs());

            Assert.IsTrue(loggerServiceMock.LogInfoMethodIsCalled);
        }
    }
    public class StubLoggingHttpContextWrapper : ILoggingHttpContextWrapper
    {
        public StubLoggingHttpContextWrapper() { }

        public HttpContextWrapper HttpContextWrapper { get; private set; }
    }

    public class MockLoggerService : ILogService
    {
        public bool LogInfoMethodIsCalled = false;
        public void LogInfo(HttpContextWrapper httpContextWrapper)
        {
            LogInfoMethodIsCalled = true;
        }
    }
}
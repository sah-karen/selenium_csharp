using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using PageObjects.PageObjects;
using Utils.Common;
using Utils.Reports;

namespace TestsDI.Common
{
    internal class TestBase
    {   
        protected IWebDriver? Driver { get; private set; }
        protected WebFormPage? WebForm { get; private set; }
        protected IBrowser? Browser { get; private set; }
        
        [SetUp]
        public void Setup()
        {
            var container = ContainerConfig.Configure();
            ExtentReporting.Instance.CreateTest(TestContext.CurrentContext.Test.MethodName);

            Driver = container.Resolve<IWebDriver>();
            Driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebForm = container.Resolve<WebFormPage>();
            Browser = container.Resolve<IBrowser>();
        }
        [TearDown]
        public void TearDown()
        {
            EndTest();
            ExtentReporting.Instance.EndReporting();
            Driver?.Quit();
        }

        private void EndTest()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status; 
            var message = TestContext.CurrentContext.Result.Message;
            switch (testStatus)
            {
                case TestStatus.Failed:
                    ExtentReporting.Instance.LogFail($"Test has failed {message}");
                    break;
                case TestStatus.Skipped:
                    ExtentReporting.Instance.LogFail($"Test skipped {message}");
                    break;
                default:
                    break;
            }

            // extent report 
            ExtentReporting.Instance.LogScreenShoot("Ending test", Browser.GetScreenshot());
        }
    }
}
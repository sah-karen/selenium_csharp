using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjects.PageObjects;
using Utils.Common;
using Utils.Reports;

namespace Tests.Common
{
    internal class TestBase
    {   
        protected IWebDriver? Driver { get; private set; }
        protected WebFormPage? WebForm { get; private set; }
        protected Browser Browser { get; private set; }
        
        [SetUp]
        public void Setup()
        {
            ExtentReporting.CreateTest(TestContext.CurrentContext.Test.MethodName);

            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebForm = new WebFormPage(Driver);
            Browser = new Browser(Driver);
        }
        [TearDown]
        public void TearDown()
        {
            EndTest();
            ExtentReporting.EndReporting();
            Driver.Quit();
        }

        private void EndTest()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status; 
            var message = TestContext.CurrentContext.Result.Message;
            switch (testStatus)
            {
                case TestStatus.Failed:
                    ExtentReporting.LogFail($"Test has failed {message}");
                    break;
                case TestStatus.Skipped:
                    ExtentReporting.LogFail($"Test skipped {message}");
                    break;
                default:
                    break;
            }
            ExtentReporting.LogScreenShoot("Ending test", Browser.GetScreenshot());
        }
    }
}
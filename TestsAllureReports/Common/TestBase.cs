using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Allure.Net.Commons;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjects.PageObjects;
using Utils.Common;
using Utils.Reports;

namespace TestsAllureReports.Common
{
    internal class TestBase
    {   
        protected IWebDriver? Driver { get; private set; }
        protected WebFormPage? WebForm { get; private set; }
        protected Browser Browser { get; private set; }
        protected AllureReporting AllureReport { get; private set; } 
        
        [SetUp]
        public void Setup()
        {
            AllureReport = new AllureReporting();

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
            Driver.Quit();
        }

        private void EndTest()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status; 
            var message = TestContext.CurrentContext.Result.Message;
            switch (testStatus)
            {
                case TestStatus.Failed:
                    AllureReport?.LogStep($"Test has failed {message}");
                    break;
                case TestStatus.Skipped:
                    AllureReport?.LogStep($"Test skipped {message}");
                    break;
                default:
                    break;
            }

            //allure report
            var screenshot = Browser.SaveScreenshot();
            TestContext.AddTestAttachment(screenshot);
            // ???? dont work from video AllureLifecycle.Instance.AddAttachment("end test", "image/png", screenshot);
            AllureApi.AddAttachment("end test", "image/png", screenshot);  

        }
    }
}
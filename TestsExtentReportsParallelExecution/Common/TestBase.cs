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

namespace TestsExtentReportsParallelExecution.Common
{
    internal class TestBase
    {   
        protected WebFormPage? WebForm { get; private set; }
        protected Browser Browser { get; private set; }
        
        [SetUp]
        public void Setup()
        {
            ExtentParallelReporting.Instance.CreateTest(TestContext.CurrentContext.Test.MethodName);

            
            GetDriver().Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");
            GetDriver().Manage().Window.Maximize();
            GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebForm = new WebFormPage(GetDriver());
            Browser = new Browser(GetDriver());
        }
        [TearDown]
        public void TearDown()
        {
            EndTest();
            ExtentParallelReporting.Instance.EndReporting();
            QuitDriver();
        }

        private void EndTest()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status; 
            var message = TestContext.CurrentContext.Result.Message;
            switch (testStatus)
            {
                case TestStatus.Failed:
                    ExtentParallelReporting.Instance.LogFail($"Test has failed {message}");
                    break;
                case TestStatus.Skipped:
                    ExtentParallelReporting.Instance.LogFail($"Test skipped {message}");
                    break;
                default:
                    break;
            }

            // extent report 
            ExtentParallelReporting.Instance.LogScreenShoot("Ending test", Browser.GetScreenshot());
        }

        private IWebDriver GetDriver ()
        {
            return WebDriverFactory.GetDriver();
        }

        private void QuitDriver()
        {
            WebDriverFactory.QuitDriver();
        }
    }
}
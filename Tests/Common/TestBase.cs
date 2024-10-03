using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjects.PageObjects;

namespace Tests.Common
{
    internal class TestBase
    {   
        protected IWebDriver? Driver { get; private set; }
        protected WebFormPage? WebForm { get; private set; }
        
        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebForm = new WebFormPage(Driver);
        }
        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
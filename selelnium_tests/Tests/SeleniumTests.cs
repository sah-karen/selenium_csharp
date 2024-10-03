using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace selelnium_tests.Tests
{
    public class SeleniumTests
    {
        [Test]
        [Category("Sel1test")]
        public void FirstSeleniumTest(){
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.selenium.dev");
            Assert.That(driver.Title, Is.EqualTo("Selenium"));
            driver.Quit();
        }
        

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace selelnium_tests.Tests
{
    public class LocatorsTests
    {
        [Test]
        public void LocatorTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.selenium.dev/documentation");
            driver.Manage().Window.Maximize();
            
            var classNameValidator = driver.FindElement(By.ClassName("DocSearch")).Displayed;
            Assert.That(classNameValidator, Is.EqualTo(true));

            var cssSelectorValidator = driver.FindElement(By.CssSelector(".DocSearch")).Displayed;
            Assert.That(cssSelectorValidator, Is.EqualTo(true));
            
            var idValidator = driver.FindElement(By.Id("Layer_1")).Displayed;
            Assert.That(idValidator, Is.EqualTo(true));

            var nameValidator = driver.FindElement(By.Name("robots"));
            Assert.That(nameValidator, Is.Not.Null);
            //
            var linkValidator = driver.FindElement(By.LinkText("Documentation")).Displayed;
            Assert.That(linkValidator, Is.EqualTo(true));

            var partiallinkValidator = driver.FindElement(By.PartialLinkText("Doc")).Displayed;
            Assert.That(partiallinkValidator, Is.EqualTo(true));

            var tagValidator = driver.FindElement(By.TagName("nav")).Displayed;
            Assert.That(tagValidator, Is.EqualTo(true));

            var xpathValidator = driver.FindElement(By.XPath("//h1")).Displayed;
            Assert.That(xpathValidator, Is.EqualTo(true));

            driver.Quit();



        }
    }
}
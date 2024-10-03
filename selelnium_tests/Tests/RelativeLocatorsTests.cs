using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace selelnium_tests.Tests
{
    public class RelativeLocatorsTests
    {
        [Test]
        public void RelativeLocatorTest(){
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.selenium.dev");
            Assert.That(driver.Title, Is.EqualTo("Selenium"));
            var knownXpath = "//h4[text()='Selenium IDE']";
            var rightOfSample = driver.FindElement(RelativeBy.WithLocator(By.TagName("h4")).RightOf(By.XPath(knownXpath))).Text;
            var leftOfSample = driver.FindElement(RelativeBy.WithLocator(By.TagName("h4")).LeftOf(By.XPath(knownXpath))).Text;
            var belowSample = driver.FindElement(RelativeBy.WithLocator(By.TagName("a")).Below(By.XPath(knownXpath))).Text;
            var aboveSample = driver.FindElement(RelativeBy.WithLocator(By.TagName("h2")).Above(By.XPath(knownXpath))).Text;

            var h2WebElement = driver.FindElement(RelativeBy.WithLocator(By.TagName("h2")).Above(By.XPath(knownXpath)));
            var chainSample = driver
                .FindElement(RelativeBy.WithLocator(By.TagName("h4"))
                .LeftOf(By.XPath(knownXpath))
                .Below(h2WebElement))
                .Text;
            var results = new List<String>() {
                rightOfSample, leftOfSample,belowSample, aboveSample, chainSample

            };    
            File.WriteAllLines("results", results);
            driver.Quit();
        }
        

    }
}
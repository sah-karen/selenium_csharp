using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace selelnium_tests.Tests
{
    public class FindElementTests
    {
        [Test]
        public void FindElements()
        {
            var results = new List<String>();

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.selenium.dev/documentation");
            driver.Manage().Window.Maximize();
            

            var firsth2 = driver.FindElement(By.XPath("//h2"));
            results.Add($"FindElement: {firsth2.Text}");

            var h2Collection = driver.FindElements(By.XPath("//h2"));

            foreach (var h2 in h2Collection)
            {
                results.Add($"FindElements: {h2.Text}");
            }

            //evaliate a subset of the DOM
            var parenElement = driver.FindElement(By.CssSelector("div[id='main_navbar']"));
            var links = parenElement.FindElements(By.TagName("a"));
            foreach (var link in links)
            {
                var result = link.Text;
                if (! string.IsNullOrEmpty(result))
                   results.Add($"Find Links {result}");
            }
            File.WriteAllLines("results", results);
            driver.Quit();



        }
    }
}
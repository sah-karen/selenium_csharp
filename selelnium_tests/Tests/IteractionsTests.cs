using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace selelnium_tests.Tests
{
    public class IteractionsTests
    {
        [Test]
        public void IteractionTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");
            driver.Manage().Window.Maximize();
            
            driver.FindElement(By.Id("my-check-2")).Click();
            driver.FindElement(By.Id("my-radio-2")).Click();
            //right click
            var actions = new Actions(driver);
            var button = driver.FindElement(By.TagName("button"));
            actions.ContextClick(button).Perform();

            //double click
            var checkbob1 = driver.FindElement(By.Id("my-check-1"));
            actions.DoubleClick(checkbob1).Perform();

            // input text
            driver.FindElement(By.Id("my-text-id")).SendKeys(Guid.NewGuid().ToString());
            //textArea
            var textArea = driver.FindElement(By.Name("my-textarea"));
            textArea.SendKeys(Guid.NewGuid().ToString());
            textArea.Clear();

            //select
            var selectElement = driver.FindElement(By.Name("my-select"));
            var select = new SelectElement(selectElement);
            select.SelectByText("One");
            select.SelectByValue("2");
            select.SelectByIndex(3);
            
            //upload
            var filePath = Path.GetTempPath() + Guid.NewGuid().ToString() + ".txt";
            File.WriteAllText(filePath, Guid.NewGuid().ToString());
            driver.FindElement(By.Name("my-file")).SendKeys(filePath);
            
            // driver.Quit();
        }
    }
}
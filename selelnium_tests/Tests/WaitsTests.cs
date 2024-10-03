using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace selelnium_tests.Tests
{
    public class WaitsTests
    {
        [Test]
        public void ImplicitWaitTest(){
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");
            driver.Manage().Window.Maximize();
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
            var textArea = driver.FindElement(By.Name("my-textarea"));
            textArea.SendKeys(Guid.NewGuid().ToString());

            driver.Quit();
        }
    
        [Test]
        public void ExplicitWaitTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");
            driver.Manage().Window.Maximize();
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            
            wait.Until(e => e.FindElement(By.Name("my-textarea")));
            wait.Until(e => e.Title == "Web form");
            wait.Until(e => e.FindElement(By.Name("my-textarea")).Displayed);
            
            var textArea = driver.FindElement(By.Name("my-textarea"));
            textArea.SendKeys(Guid.NewGuid().ToString());

            driver.Quit();
        }


        [Test]
        public void FluentWaitTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");
            driver.Manage().Window.Maximize();
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromSeconds(1)
            };

            wait.IgnoreExceptionTypes(typeof(HttpRequestException));
            var condition = wait.Until(e => e.Title == "Web form");

            var textArea = driver.FindElement(By.Name("my-textarea"));
            textArea.SendKeys(Guid.NewGuid().ToString());

            driver.Quit();
        }


    }
}
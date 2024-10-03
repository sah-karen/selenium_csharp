using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace PageObjects.PageObjects
{
    public class TargetPage
    {
        IWebDriver driver;
        IWebElement Message => driver.FindElement(By.Id("message"));
        public TargetPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public string GetMessage()
        {
            return Message.Text;
        }
    }
}
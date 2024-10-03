using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace PageObjects.PageObjects
{
    public class WebFormPage
    {
        //locators
        IWebElement TextArea => driver.FindElement(By.Name("my-textarea"));
        IWebElement SubmitButton => driver.FindElement(By.TagName("button"));
        IWebDriver driver;
        public WebFormPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //methods
        public WebFormPage WriteTextToTextArea(string text)
        {
            TextArea.SendKeys(text);
            return this;
        }
        
        public TargetPage SubmitForm()
        {
            SubmitButton.Click();
            return new TargetPage(driver);
        }
    }
}
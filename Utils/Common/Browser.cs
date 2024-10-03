using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Utils.Common
{
    public class Browser
    {
        IWebDriver driver;
        public Browser(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetScreenshot()
        {
            var file = ((ITakesScreenshot)driver).GetScreenshot();
            var img = file.AsBase64EncodedString;
            return img;
        }
    }

}
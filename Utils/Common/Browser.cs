using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Utils.Common
{
    public class Browser: IBrowser
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

        public string SaveScreenshot()
        {
            var fileName = Guid.NewGuid().ToString();
            var directory = Directory.CreateDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                + "\\screenshots\\").FullName;
            var filePath = directory + fileName;    
            var file = ((ITakesScreenshot)driver).GetScreenshot();
            file.SaveAsFile(filePath);
            return filePath;

        }
    }

}
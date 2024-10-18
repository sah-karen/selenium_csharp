using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestsExtentReportsParallelExecution.Common
{
    internal class WebDriverFactory
    {
        private static ThreadLocal<IWebDriver> webDriverThreadLocal = new ThreadLocal<IWebDriver>();
        private static readonly object myLock = new object();

        public static IWebDriver GetDriver()
        {
            lock (myLock)
            {
                IWebDriver driver = webDriverThreadLocal.Value;
                if (driver == null)
                {
                    driver = new ChromeDriver();
                    webDriverThreadLocal.Value = driver;
                }
                return driver;
            }
        }

        public static void QuitDriver()
        {
            lock(myLock) 
            {
                if (webDriverThreadLocal.Value != null) 
                {
                    webDriverThreadLocal.Value.Quit();
                    webDriverThreadLocal.Value = null;
                }
            }
        }
    }
}
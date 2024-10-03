using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace selelnium_tests.Tests
{
    public class BrowsersTests
    {
        [Test]
        public void ChromeBrowser()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.selenium.dev");
            Assert.That(driver.Title,Is.EqualTo("Selenium"));
            driver.Quit();
        }

        [Test]
        public void FireFoxBrowser()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.selenium.dev");
            Assert.That(driver.Title,Is.EqualTo("Selenium"));
            driver.Quit();
        }

        [Test]
        public void EdgeBrowser()
        {
            IWebDriver driver = new EdgeDriver();
            driver.Navigate().GoToUrl("https://www.selenium.dev");
            Assert.That(driver.Title,Is.EqualTo("Selenium"));
            driver.Quit();
        }

    }
}
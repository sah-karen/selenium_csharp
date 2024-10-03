namespace selelnium_tests;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class SeleniumTests
{
    IWebDriver driver = new ChromeDriver();

    [Test] 
    [Category("Selenium")]
    public void FirstTest()
    {
        driver.Navigate().GoToUrl("https://www.selenium.dev");
        Assert.That(driver.Title, Is.EqualTo("Selenium"));
    }
    [Test] 
    public void SecondTest()
    {
        driver.Navigate().GoToUrl("https://www.google.com");
        driver.Manage().Window.Maximize();
        IWebElement webElement = driver.FindElement(By.Name("q"));
        webElement.SendKeys("Selenium");
        webElement.SendKeys(Keys.Enter);
        
    }

    [TearDown]
    public void TearDown(){
       // driver.Quit(); 
    }

}

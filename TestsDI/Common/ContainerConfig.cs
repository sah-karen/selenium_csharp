using Autofac;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Utils.Common;
using PageObjects.PageObjects;


namespace TestsDI.Common
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ChromeDriver>().As<IWebDriver>().SingleInstance();
            builder.RegisterType<Browser>().As<IBrowser>();
            builder.RegisterType<WebFormPage>();
            return builder.Build();
        }
    }
}
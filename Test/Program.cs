using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QAutomation.Core.Interfaces;
using QAutomation.Core.Interfaces.Controls;
using QAutomation.Selenium;
using QAutomation.Selenium.Configs;
using QAutomation.Selenium.Controls;
using System;
using Unity;
using Unity.Resolution;
using QAutomation.Core;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            var config = new ChromeWebDriverConfig();

            container.RegisterType<IElement, Element>();
            container.RegisterType<IFrameElement, FrameElement>();

            container.RegisterType<IDriver, WebDriver>();

            var driver = container.Resolve<IDriver>(new ResolverOverride[]
            {
                new ParameterOverride("config", config),
                new ParameterOverride("container", container)
             });

            driver.Navigate().Url("https://yandex.ru");

            driver.ExecuteJavaScript("arguments[0].click()", new object[] { driver.Find<IElement>(new QAutomation.Core.By(LocatorType.Xpath, ".//*[@class='region__cityname']"))});
        }
    }
}

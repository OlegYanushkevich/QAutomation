using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QAutomation.Core.Interfaces.Controls;
using QAutomation.Selenium;
using QAutomation.Selenium.Configs;
using QAutomation.Selenium.Controls;
using System;
using Unity;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var container = new UnityContainer();

            container.RegisterType<IElement, Element>();
            container.RegisterType<IFrameElement, FrameElement>();

            var config = new ChromeWebDriverConfig();

            var driver = new WebDriver(config, container);

            driver.Navigate().Url("https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_iframe");

            var src = driver.Manage().Windows().Current.Source;

            var element = driver.Find<FrameElement>(new QAutomation.Core.By(QAutomation.Core.LocatorType.Xpath, ".//iframe[@id='iframeResult']"));

            var body = driver._finderService.Find<IElement>(element, new QAutomation.Core.By(QAutomation.Core.LocatorType.Xpath, ".//body"));

            var neww = driver.SwitchTo().DefaultContent();

            driver.Manage().Windows().Current.FullScreen();
        }
    }
}

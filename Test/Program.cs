namespace Test
{
    using System;
    using QAutomation.Core;
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Selenium;
    using QAutomation.Selenium.Configs;
    using QAutomation.Selenium.Controls;
    using Unity;

    internal static class Program
    {
        private static void Main(string[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            var container = new UnityContainer();
            var config = new ChromeWebDriverConfig();

            container.RegisterType<IElement, Element>();
            container.RegisterType<IFrameElement, FrameElement>();
            container.RegisterType<INavigationService, NavigationService>();
            container.RegisterType<IManageOptions, ManageOptionsService>();
            container.RegisterType<ICookiesService, CookiesService>();
            container.RegisterType<IWindowsService, WindowsService>();
            container.RegisterType<ITargetLocatorService, TargetLocatorService>();

            container.RegisterType<IDriver, WebDriver>();
            container.RegisterInstance<WebDriverConfig>(config);
            container.RegisterInstance<IUnityContainer>(container);

            var driver = container.Resolve<IDriver>();

            driver.Navigate().Url("https://products.office.com/en-us/try");
            var tl = driver.SwitchTo();
            var t1l = driver.SwitchTo();

            Console.WriteLine(t1l == tl);

            var elements = driver.FindAll<IElement>(Locator.CssSelector("[id^='lnk-']"));
            var content = System.Linq.Enumerable.ElementAt(elements, 0).Content;
            //driver.ExecuteJavaScript("arguments[0].click()", new object[] { driver.Find<IElement>(new QAutomation.Core.By(LocatorType.Xpath, ".//*[@class='region__cityname']"))});
        }
    }
}

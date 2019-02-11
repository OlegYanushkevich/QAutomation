namespace Test
{
    using NLog;
    using NLog.Config;
    using NLog.Targets;
    using QAutomation.AspectInjector;
    using QAutomation.Core;
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Selenium;
    using QAutomation.Selenium.Configs;
    using QAutomation.Selenium.Controls;
    using Unity;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var cfg = new LoggingConfiguration();
            var target = new ConsoleTarget("logconsole");

            cfg.AddTarget(target);
            cfg.AddRuleForAllLevels(target);

            LogManager.Configuration = cfg;

            var container = new UnityContainer();
            var config = new ChromeWebDriverConfig();

            container.RegisterType<IElement, Element>();
            container.RegisterType<ITextElement, TextElement>();
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

            driver.Navigate().Url("https://google.com");

            var input = driver.Find<ITextElement>(Locator.CssSelector("[name='q']"));
            input.SendKeys("Oleg Yanushkevich");

            var findBtn = driver.Find<IElement>(Locator.XPath("(.//input[@name='btnK'])[2]"));

            findBtn.Click();

            driver.Quit();
        }
    }
}

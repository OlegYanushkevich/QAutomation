namespace Test
{
    using Autofac;
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Selenium;
    using QAutomation.Selenium.Configs;
    using QAutomation.Selenium.Controls;

    public static class DependencyResolver
    {
        private readonly static IContainer _container;

        static DependencyResolver()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Element>()
                .As<IElement>();

            builder.RegisterType<TextElement>()
                .As<ITextElement>();

            builder.RegisterType<FrameElement>()
                .As<IFrameElement>();

            builder.RegisterType<NavigationService>()
                .As<INavigationService>();

            builder.RegisterType<Window>()
                .As<IWindow>();

            builder.RegisterType<ManageOptionsService>()
                .As<IManageOptions>();

            builder.RegisterType<Alert>()
                .As<IAlert>();

            builder.RegisterType<ManageOptionsService>()
               .As<IManageOptions>();

            builder.RegisterType<CookiesService>()
               .As<ICookiesService>();

            builder.RegisterType<WindowsService>()
              .As<IWindowsService>();

            builder.RegisterType<TargetLocatorService>()
              .As<ITargetLocatorService>();

            builder.RegisterType<WebDriver>()
              .As<IDriver>()
              .InstancePerLifetimeScope();

            var config = new ChromeWebDriverConfig();

            builder.RegisterInstance<WebDriverConfig>(config);

            _container = builder.Build();
        }

        public static IContainer GetResolver() => _container;
    }
}

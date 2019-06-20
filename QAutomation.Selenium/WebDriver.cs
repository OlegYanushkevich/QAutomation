namespace QAutomation.Selenium
{
    using Autofac;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Internal;
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Selenium.Configs;
    using System.Collections.Generic;

    public partial class WebDriver : IDriver, IWrapsDriver
    {
        private readonly WebDriverConfig _config;

        private readonly ILifetimeScope _scope;

        private readonly ElementFinderService _finderService;

        private IWebDriver driver;

        private IWaitingService waiting;

        private IManageOptions manageOptions;

        private INavigationService navigation;

        private ITargetLocatorService targetLocator;

        public WebDriver(WebDriverConfig config, ILifetimeScope scope)
        {
            _scope = scope;
            _config = config;

            _finderService = new ElementFinderService(_scope);
        }

        public IWebDriver WrappedDriver => driver ?? (driver = _config.CreateDriver());

        public IDriverConfig Config => _config;

        internal IFrameElement CurrentFrame { get; set; }

        public IManageOptions Manage()
        {
            if (manageOptions == null)
            {
                var cookieService = _scope.Resolve<ICookiesService>(new TypedParameter(typeof(ICookieJar), WrappedDriver.Manage().Cookies));
                var windowsService = _scope.Resolve<IWindowsService>(new TypedParameter(typeof(IWebDriver), WrappedDriver));

                manageOptions = _scope.Resolve<IManageOptions>
                (
                    new TypedParameter(typeof(ICookiesService), cookieService),
                    new TypedParameter(typeof(IWindowsService), windowsService)
                );
            }

            return manageOptions;
        }

        public INavigationService Navigate() => navigation ??
                  (navigation = _scope.Resolve<INavigationService>(new TypedParameter(typeof(INavigation), WrappedDriver.Navigate())));

        public ITargetLocatorService SwitchTo() => targetLocator ??
                  (targetLocator = _scope.Resolve<ITargetLocatorService>(new TypedParameter(typeof(WebDriver), this)));

        public IWaitingService Wait()
            => waiting ?? (waiting = _scope.Resolve<IWaitingService>(new TypedParameter(typeof(WebDriver), this)));

        public TElement Find<TElement>(Core.Locator locator) where TElement : IElement
            => _finderService.Find<TElement>(this, locator);

        public IEnumerable<TElement> FindAll<TElement>(Core.Locator locator) where TElement : IElement
            => _finderService.FindAll<TElement>(this, locator);

        public void Quit() => WrappedDriver.Quit();
    }
}

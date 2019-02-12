namespace QAutomation.Selenium
{
    using System.Collections.Generic;
    using global::Unity;
    using global::Unity.Resolution;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Internal;
    using QAutomation.AspectInjector;
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Selenium.Configs;

    //[Logged]
    public partial class WebDriver : IDriver, IWrapsDriver
    {
        private readonly ElementFinderService finderService;

        internal readonly IUnityContainer Container;

        private readonly WebDriverConfig config;

        private IWebDriver driver;

        private IManageOptions manageOptions;

        private ITargetLocatorService targetLocator;

        private INavigationService navigation;

        private IWaitingService waiting;

        internal IFrameElement CurrentFrame { get; set; }

        public IWebDriver WrappedDriver => driver ?? (driver = config.CreateDriver());

        public IDriverConfig Config => config;

        public WebDriver(WebDriverConfig config, IUnityContainer container)
        {
            this.Container = container;
            this.config = config;

            this.finderService = new ElementFinderService(this.Container);
        }

        public IManageOptions Manage()
        {
            if (manageOptions == null)
            {
                var cookieService = this.Container.Resolve<ICookiesService>(new ParameterOverride("cookieJar", WrappedDriver.Manage().Cookies));
                var windowsService = this.Container.Resolve<IWindowsService>(new ParameterOverride("driver", WrappedDriver), new ParameterOverride("container", this.Container));

                this.manageOptions = this.Container.Resolve<IManageOptions>(new ResolverOverride[]
                {
                    new ParameterOverride("cookiesService", cookieService),
                    new ParameterOverride("windowsService", windowsService)
                });
            }
            return this.manageOptions;
        }

        public INavigationService Navigate()
        {
            return this.navigation ??
                  (this.navigation = this.Container.Resolve<INavigationService>(new ResolverOverride[] { new ParameterOverride("navigation", WrappedDriver.Navigate()) }));
        }

        public ITargetLocatorService SwitchTo()
        {
            return this.targetLocator ??
                  (this.targetLocator = this.Container.Resolve<ITargetLocatorService>(new ParameterOverride("driver", this)));
        }

        public IWaitingService Wait()
            => this.waiting ?? (this.waiting = this.Container.Resolve<IWaitingService>(new ParameterOverride("driver", this)));

        public TElement Find<TElement>(Core.Locator locator) where TElement : IElement => this.finderService.Find<TElement>(this, locator);

        public IEnumerable<TElement> FindAll<TElement>(Core.Locator locator) where TElement : IElement => this.finderService.FindAll<TElement>(this, locator);

        public void Quit() => WrappedDriver.Close();
    }
}

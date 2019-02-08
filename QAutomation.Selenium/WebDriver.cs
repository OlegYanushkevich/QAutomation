namespace QAutomation.Selenium
{
    using System.Collections.Generic;
    using global::Unity;
    using global::Unity.Resolution;
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Selenium.Configs;

    public partial class WebDriver : IDriver
    {
        private readonly ElementFinderService finderService;

        private readonly IUnityContainer container;

        private readonly WebDriverConfig config;

        private IWebDriver driver;

        private IManageOptions manageOptions;

        private ITargetLocatorService targetLocator;

        private INavigationService navigation;

        private IWaitingService waiting;

        internal IFrameElement CurrentFrame { get; set; }

        public IWebDriver Driver => driver ?? (driver = config.CreateDriver());

        public IDriverConfig Config => config;

        public WebDriver(WebDriverConfig config, IUnityContainer container)
        {
            this.container = container;
            this.config = config;

            this.finderService = new ElementFinderService(this.container);
        }

        public IManageOptions Manage()
        {
            if (manageOptions == null)
            {
                var cookieService = this.container.Resolve<ICookiesService>(new ParameterOverride("cookieJar", Driver.Manage().Cookies));
                var windowsService = this.container.Resolve<IWindowsService>(new ParameterOverride("driver", Driver));

                this.manageOptions = this.container.Resolve<IManageOptions>(new ResolverOverride[]
                {
                    new ParameterOverride("cookieService", cookieService),
                    new ParameterOverride("windowsSerivce", windowsService)
                });
            }
            return this.manageOptions;
        }

        public INavigationService Navigate()
        {
            return this.navigation ??
                  (this.navigation = this.container.Resolve<INavigationService>(new ResolverOverride[] { new ParameterOverride("navigation", Driver.Navigate()) }));
        }

        public ITargetLocatorService SwitchTo()
        {
            return this.targetLocator ??
                  (this.targetLocator = this.container.Resolve<ITargetLocatorService>(new ResolverOverride[] { new ParameterOverride("driver", this) }));
        }

        public IWaitingService Wait()
            => this.waiting ?? (this.waiting = this.container.Resolve<IWaitingService>(new ResolverOverride[] { new ParameterOverride("driver", this) }));

        public TElement Find<TElement>(Core.Locator locator) where TElement : IElement => this.finderService.Find<TElement>(this, locator);

        public IEnumerable<TElement> FindAll<TElement>(Core.Locator locator) where TElement : IElement => this.finderService.FindAll<TElement>(this, locator);
    }
}

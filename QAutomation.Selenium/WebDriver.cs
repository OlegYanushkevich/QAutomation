namespace QAutomation.Selenium
{
    using global::Unity;
    using global::Unity.Resolution;
    using OpenQA.Selenium;
    using QAutomation.Core;
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Selenium.Configs;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Unity;

    public class WebDriver : IDriver
    {
        internal IFrameElement CurrentFrame { get; set; }

        public ElementFinderService _finderService;

        private IWebDriver _driver;
        public IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                    _driver = _config.CreateDriver();

                return _driver;
            }
        }

        private readonly IUnityContainer _container;

        private WebDriverConfig _config;
        public IDriverConfig Config => _config;

        public WebDriver(WebDriverConfig config, IUnityContainer container)
        {
            _container = container;
            _config = config;

            _finderService = new ElementFinderService(_container);
        }

        public T ExecuteJavaScript<T>(string script)
        {
            throw new NotImplementedException();
        }

        public IManageOptions Manage() => new ManageOptionsService(Driver);
        public INavigationService Navigate() => new NavigationService(Driver.Navigate());


        public ITargetLocatorService SwitchTo() => new TargetLocatorService(this);

        public IWaitingService Wait()
        {
            throw new NotImplementedException();
        }

        public TElement Find<TElement>(Core.By by) where TElement : IElement
        {
            return _finderService.Find<TElement>(this, null, by);
        }

        public IEnumerable<TElement> FindAll<TElement>(Core.By by) where TElement : IElement
        {
            throw new NotImplementedException();
        }
    }
}

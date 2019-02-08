namespace QAutomation.Selenium.Configs
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces;
    using System;

    public abstract class WebDriverConfig : IDriverConfig
    {
        public int ProcessID { get; set; }

        public virtual string Version { get; set; } = "any";

        public TimeSpan CommandTimeout { get; set; } = TimeSpan.FromSeconds(65);

        public TimeSpan SearchTimeout { get; set; } = TimeSpan.FromSeconds(0);

        public TimeSpan PageLoadTimeout { get; set; } = TimeSpan.FromSeconds(60);

        public TimeSpan AsyncJavaScriptTimeout { get; set; } = TimeSpan.FromSeconds(60);

        public TimeSpan WaitTimeout { get; set; } = TimeSpan.FromSeconds(60);

        public TimeSpan PollingInterval { get; set; } = TimeSpan.FromSeconds(2);

        public string GridUri { get; set; }
        public bool UseGrid { get; set; }

        public string Proxy { get; set; }

        public string ProxyAutoConfigUrl { get; set; }

        public IWebDriver CreateDriver()
        {
            IWebDriver driver = UseGrid ? CreateRemoteDriver() : CreateLocalDriver();

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = SearchTimeout;
            driver.Manage().Timeouts().PageLoad = PageLoadTimeout;
            driver.Manage().Timeouts().AsynchronousJavaScript = AsyncJavaScriptTimeout;

            return driver;
        }

        /// <summary>
        /// Configuration and getting new instance of the <see cref="IWebDriver"/> interface
        /// </summary>
        /// <returns><see cref="IWebDriver"/></returns>
        public abstract IWebDriver CreateRemoteDriver();
        public abstract IWebDriver CreateLocalDriver();

        public Proxy GetProxy()
        {
            if (Proxy != null || ProxyAutoConfigUrl != null)
            {
                var proxy = new Proxy();
                proxy.AddBypassAddresses("localhost", "127.0.0.1");

                if (ProxyAutoConfigUrl != null)
                {
                    proxy.Kind = ProxyKind.ProxyAutoConfigure;
                    proxy.ProxyAutoConfigUrl = ProxyAutoConfigUrl;
                }
                if (Proxy != null)
                {
                    proxy.Kind = ProxyKind.Manual;
                    proxy.HttpProxy = Proxy;
                    proxy.SslProxy = Proxy;
                }
                return proxy;
            }

            return null;
        }
    }
}

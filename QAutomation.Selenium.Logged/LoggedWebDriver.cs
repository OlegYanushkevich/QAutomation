namespace QAutomation.Selenium.Logged
{
    using System;
    using System.Collections.Generic;
    using QAutomation.AspectInjector;
    using QAutomation.Core;
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;
   
    public class LoggedWebDriver : IDriver
    {
        private readonly IDriver decoratedWebDriver;

        public IDriverConfig Config => this.decoratedWebDriver.Config;

        public LoggedWebDriver(IDriver decoratedDriver)
        {
            this.decoratedWebDriver = decoratedDriver ?? throw new NullReferenceException(nameof(decoratedDriver));
        }

        [Logged]
        public TElement Find<TElement>(Locator by) where TElement : IElement
            => this.decoratedWebDriver.Find<TElement>(by);

        [Logged]
        public IEnumerable<TElement> FindAll<TElement>(Locator by) where TElement : IElement
            => this.decoratedWebDriver.FindAll<TElement>(by);

        public IManageOptions Manage() => this.decoratedWebDriver.Manage();

        public INavigationService Navigate() => this.decoratedWebDriver.Navigate();

        [Logged]
        public void Quit() => this.decoratedWebDriver.Quit();

        public ITargetLocatorService SwitchTo() => this.decoratedWebDriver.SwitchTo();

        public IWaitingService Wait() => this.decoratedWebDriver.Wait();

        #region JavaScriptExecutor
        [Logged]
        public void ExecuteJavaScript(string script) => this.decoratedWebDriver.ExecuteJavaScript(script);

        [Logged]
        public void ExecuteJavaScript(string script, object[] args) => this.decoratedWebDriver.ExecuteJavaScript(script, args);

        [Logged]
        public T ExecuteJavaScript<T>(string script) => this.decoratedWebDriver.ExecuteJavaScript<T>(script);

        [Logged]
        public T ExecuteJavaScript<T>(string script, object[] args) => this.decoratedWebDriver.ExecuteJavaScript<T>(script, args);
        #endregion
    }
}

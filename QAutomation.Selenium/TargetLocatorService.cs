namespace QAutomation.Selenium
{
    using Autofac;
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;

    /// <summary>
    /// Service for switching between different entities
    /// </summary>
    public class TargetLocatorService : ITargetLocatorService
    {
        private readonly WebDriver _driver;
        private readonly ILifetimeScope _scope;

        private IAlert _alert;

        public TargetLocatorService(WebDriver driver, ILifetimeScope scope)
        {
            _driver = driver;
            _scope = scope;
        }

        public IAlert Alert() =>
            _alert ?? (_alert = _scope.Resolve<IAlert>(new TypedParameter(typeof(OpenQA.Selenium.IAlert), _driver.WrappedDriver.SwitchTo().Alert())));

        public IDriver DefaultContent()
        {
            if (_driver.CurrentFrame != null)
            {
                _driver.WrappedDriver.SwitchTo().DefaultContent();
                _driver.CurrentFrame = null;
            }

            return _driver;
        }

        public IDriver Frame(Core.Locator by) => _driver.Find<IFrameElement>(by).Switch();

        public IDriver Frame(IFrameElement frame) => frame.Switch();

        public IWindow Window(string handle)
        {
            _driver.WrappedDriver.SwitchTo().Window(handle);
            return _driver.Manage().Windows().Current;
        }
    }
}

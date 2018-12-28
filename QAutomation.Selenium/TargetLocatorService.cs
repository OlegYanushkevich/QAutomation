namespace QAutomation.Selenium
{
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Selenium.Controls;

    public class TargetLocatorService : ITargetLocatorService
    {
        private readonly WebDriver _driver;

        public TargetLocatorService(WebDriver driver)
        {
            _driver = driver;
        }

        public IAlert Alert() => new Alert(_driver.Driver.SwitchTo().Alert());


        public IDriver DefaultContent()
        {
            if (_driver.CurrentFrame != null)
            {
                _driver.Driver.SwitchTo().DefaultContent();
                _driver.CurrentFrame = null;
            }

            return _driver;
        }

        public IDriver Frame(Core.By by) => _driver.Find<IFrameElement>(by).Switch();

        public IDriver Frame(IFrameElement frame) => frame.Switch();

        public IWindow Window(string handle)
        {
            _driver.Driver.SwitchTo().Window(handle);
            return _driver.Manage().Windows().Current;
        }
    }
}

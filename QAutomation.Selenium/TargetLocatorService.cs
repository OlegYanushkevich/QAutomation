namespace QAutomation.Selenium
{
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;

    /// <summary>
    /// Service for switching between different entities
    /// </summary>
    public class TargetLocatorService : ITargetLocatorService
    {
        private readonly WebDriver _driver;

        public TargetLocatorService(WebDriver driver)
        {
            this._driver = driver;
        }

        public IAlert Alert() => new Alert(this._driver.Driver.SwitchTo().Alert());

        public IDriver DefaultContent()
        {
            if (this._driver.CurrentFrame != null)
            {
                this._driver.Driver.SwitchTo().DefaultContent();
                this._driver.CurrentFrame = null;
            }

            return this._driver;
        }

        public IDriver Frame(Core.Locator by) => this._driver.Find<IFrameElement>(by).Switch();

        public IDriver Frame(IFrameElement frame) => frame.Switch();

        public IWindow Window(string handle)
        {
            this._driver.Driver.SwitchTo().Window(handle);
            return this._driver.Manage().Windows().Current;
        }
    }
}

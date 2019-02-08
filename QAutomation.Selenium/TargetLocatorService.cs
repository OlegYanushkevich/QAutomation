namespace QAutomation.Selenium
{
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;

    /// <summary>
    /// Service for switching between different entities
    /// </summary>
    public class TargetLocatorService : ITargetLocatorService
    {
        private readonly WebDriver webDriver;

        public TargetLocatorService(WebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public IAlert Alert() => new Alert(this.webDriver.Driver.SwitchTo().Alert());

        public IDriver DefaultContent()
        {
            if (this.webDriver.CurrentFrame != null)
            {
                this.webDriver.Driver.SwitchTo().DefaultContent();
                this.webDriver.CurrentFrame = null;
            }

            return this.webDriver;
        }

        public IDriver Frame(Core.Locator by) => this.webDriver.Find<IFrameElement>(by).Switch();

        public IDriver Frame(IFrameElement frame) => frame.Switch();

        public IWindow Window(string handle)
        {
            this.webDriver.Driver.SwitchTo().Window(handle);
            return this.webDriver.Manage().Windows().Current;
        }
    }
}

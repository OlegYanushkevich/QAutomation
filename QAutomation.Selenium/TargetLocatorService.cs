namespace QAutomation.Selenium
{
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;
    using Unity;
    using Unity.Resolution;

    /// <summary>
    /// Service for switching between different entities
    /// </summary>
    public class TargetLocatorService : ITargetLocatorService
    {
        private readonly WebDriver driver;

        private IAlert alert;

        public TargetLocatorService(WebDriver driver)
        {
            this.driver = driver;
        }

        public IAlert Alert() =>
            alert ?? (alert = driver.Container.Resolve<IAlert>(new ParameterOverride(nameof(alert), driver.WrappedDriver.SwitchTo().Alert())));

        public IDriver DefaultContent()
        {
            if (this.driver.CurrentFrame != null)
            {
                this.driver.WrappedDriver.SwitchTo().DefaultContent();
                this.driver.CurrentFrame = null;
            }

            return this.driver;
        }

        public IDriver Frame(Core.Locator by) => this.driver.Find<IFrameElement>(by).Switch();

        public IDriver Frame(IFrameElement frame) => frame.Switch();

        public IWindow Window(string handle)
        {
            this.driver.WrappedDriver.SwitchTo().Window(handle);
            return this.driver.Manage().Windows().Current;
        }
    }
}

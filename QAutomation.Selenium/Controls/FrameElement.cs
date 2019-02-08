namespace QAutomation.Selenium.Controls
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;
    using global::Unity;

    public class FrameElement : Element, IFrameElement
    {
        public FrameElement(WebDriver driver, IWebElement element, Core.Locator locator, IUnityContainer container)
            : base(driver, element, locator, container) { }

        public IDriver Switch()
        {
            if (this.WebDriver.CurrentFrame != this)
            {
                this.WebDriver.Driver.SwitchTo().Frame(this.WrappedElement);
                this.WebDriver.CurrentFrame = this;
            }

            return this.WebDriver;
        }
    }
}

namespace QAutomation.Selenium.Controls
{
    using Autofac;
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;

    public class FrameElement : Element, IFrameElement
    {
        public FrameElement(WebDriver driver, IWebElement element, Core.Locator locator, ILifetimeScope scope)
            : base(driver, element, locator, scope) { }

        public IDriver Switch()
        {
            if (WebDriver.CurrentFrame != this)
            {
                WebDriver.WrappedDriver.SwitchTo().Frame(WrappedElement);
                WebDriver.CurrentFrame = this;
            }

            return WebDriver;
        }
    }
}

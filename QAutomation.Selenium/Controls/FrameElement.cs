namespace QAutomation.Selenium.Controls
{
    using global::Unity;
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;

    public class FrameElement : Element, IFrameElement
    {
        public FrameElement(WebDriver driver, IWebElement element, Core.By locator, IUnityContainer container)
            : base(driver, element, locator, container)
        {
        }

        public IDriver Switch()
        {
            if(WebDriver.CurrentFrame != this)
            {
                WebDriver.Driver.SwitchTo().Frame(WrappedElement);
                WebDriver.CurrentFrame = this;
            }

            return WebDriver;
        }
    }
}

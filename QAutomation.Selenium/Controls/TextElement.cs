namespace QAutomation.Selenium.Controls
{
    using Unity;
    using OpenQA.Selenium;
    using QAutomation.Core;
    using QAutomation.Core.Interfaces.Controls;

    public class TextElement : Element, ITextElement
    {
        public TextElement(WebDriver driver, IWebElement element, Locator locator, IUnityContainer container)
            : base(driver, element, locator, container) { }
       

        public void SendKeys(string text) => this.WrappedElement.SendKeys(text);
    }
}

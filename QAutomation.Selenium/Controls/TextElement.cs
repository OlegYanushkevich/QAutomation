namespace QAutomation.Selenium.Controls
{
    using Autofac;
    using OpenQA.Selenium;
    using QAutomation.Core;
    using QAutomation.Core.Interfaces.Controls;

    public class TextElement : Element, ITextElement
    {
        public TextElement(WebDriver driver, IWebElement element, Locator locator, ILifetimeScope scope)
            : base(driver, element, locator, scope) { }


        public void SendKeys(string text) => WrappedElement.SendKeys(text);
    }
}

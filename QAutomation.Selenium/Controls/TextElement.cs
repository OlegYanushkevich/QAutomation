namespace QAutomation.Selenium.Controls
{
    using OpenQA.Selenium;
    using QAutomation.Core;
    using QAutomation.Core.Interfaces.Controls;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Unity;

    public class TextElement : Element, ITextElement
    {
        public TextElement(WebDriver driver, IWebElement element, Locator locator, IUnityContainer container)
            : base(driver, element, locator, container) { }
       

        public void SendKeys(string text) => WrappedElement.SendKeys(text);
    }
}

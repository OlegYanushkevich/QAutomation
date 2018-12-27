namespace QAutomation.Selenium.Controls
{
    using global::Unity;
    using OpenQA.Selenium;
    using QAutomation.Core;
    using QAutomation.Core.Interfaces.Controls;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Unity;

    public class FrameElement : Element, IFrameElement
    {
        public FrameElement(IWebDriver driver, IWebElement element, Core.By locator, IUnityContainer container)
            : base(driver, element, locator, container)
        {
        }
    }
}

namespace QAutomation.Selenium.Controls
{
    using global::Unity;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Internal;
    using QAutomation.Core;
    using QAutomation.Core.Interfaces.Controls;
    using System;

    public class Element : IWrapsElement, IElement
    {
        public WebDriver WebDriver;

        private readonly ElementFinderService _service;

        public IWebElement WrappedElement { get; }

        internal ISearchContext Context => WrappedElement ?? Driver as ISearchContext;

        public Element(WebDriver driver, IWebElement element, Locator locator, IUnityContainer container)
        {
            WrappedElement = element;
            WebDriver = driver;

            Locator = locator;
            _service = new ElementFinderService(container);
        }

        public IWebDriver Driver => WebDriver.Driver;

        public string Content => WrappedElement.Text;

        public Point Location => new Point(WrappedElement.Location.X, WrappedElement.Location.Y);

        public Size Size => new Size(WrappedElement.Size.Width, WrappedElement.Size.Width);

        public State State
        {
            get
            {
                var accomulator = State.None;

                if (WrappedElement.Displayed)
                    accomulator |= State.Present;
                else
                    accomulator |= State.Absent;

                if (WrappedElement.Enabled)
                    accomulator |= State.Enabled;
                else
                    accomulator |= State.Disabled;

                return accomulator;
            }
        }

        public Locator Locator { get; set; }

        public string GetAttribute(string attributeName) => WrappedElement.GetAttribute(attributeName);
        public string GetProperty(string propertyName) => WrappedElement.GetProperty(propertyName);
        public string GetCssValue(string cssStyleName) => WrappedElement.GetCssValue(cssStyleName);

        public void Click() => WrappedElement.Click();
    }
}

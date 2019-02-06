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

        private readonly IUnityContainer _container;
        private readonly ElementFinderService _service;

        public IWebElement WrappedElement { get; }

        internal ISearchContext Context => WrappedElement ?? Driver as ISearchContext;

        public Element(WebDriver driver, IWebElement element, Core.By locator, IUnityContainer container)
        {
            WrappedElement = element;
            Locator = locator;

            _container = container;
            _service = new ElementFinderService(_container);
            WebDriver = driver;
        }

        public IWebDriver Driver => WebDriver.Driver;

        public string Content => WrappedElement.Text;

        public Point Location => new Point(WrappedElement.Location.X, WrappedElement.Location.Y);

        public Size Size => new Size(WrappedElement.Size.Width, WrappedElement.Size.Width);

        public State State => throw new NotImplementedException();

        public Core.By Locator { get; set; }

        public string GetAttribute(string attributeName) => WrappedElement.GetAttribute(attributeName);
        public string GetProperty(string propertyName) => WrappedElement.GetProperty(propertyName);
        public string GetCssValue(string cssStyleName) => WrappedElement.GetCssValue(cssStyleName);
    }
}

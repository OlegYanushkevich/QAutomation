namespace QAutomation.Selenium.Controls
{
    using global::Unity;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using QAutomation.Core;
    using QAutomation.Core.Interfaces.Controls;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Unity;

    public class Element : IElement
    {
        public WebDriver WebDriver;

        private readonly IUnityContainer _container;
        private readonly ElementFinderService _service;

        private IWebElement _element;
        public IWebElement WrappedElement => _element;

        internal ISearchContext Context => _element ?? Driver as ISearchContext;

        public Element(WebDriver driver, IWebElement element, Core.By locator, IUnityContainer container)
        {
            _element = element;
            Locator = locator;

            _container = container;
            _service = new ElementFinderService(_container);
            WebDriver = driver;
        }

        public IWebDriver Driver => WebDriver.Driver;

        public string Content => _element.Text;

        public Point Location => new Point(_element.Location.X, _element.Location.Y);

        public Size Size => new Size(_element.Size.Width, _element.Size.Width);

        public State State => throw new NotImplementedException();

        public Core.By Locator { get; set; }

        public string GetAttribute(string attributeName) => _element.GetAttribute(attributeName);
        public string GetProperty(string propertyName) => _element.GetProperty(propertyName);
        public string GetCssValue(string cssStyleName) => _element.GetCssValue(cssStyleName);
    }
}

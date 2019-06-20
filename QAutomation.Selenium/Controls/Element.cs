namespace QAutomation.Selenium.Controls
{
    using System;
    using System.Collections.Generic;
    using Autofac;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Internal;
    using QAutomation.Core;
    using QAutomation.Core.Interfaces.Controls;

    public class Element : IWrapsElement, IElement
    {
        private readonly ElementFinderService _service;

        public WebDriver WebDriver { get; }

        private IWebElement _wrappedElement;

        public IWebElement WrappedElement
        {
            get
            {
                return IsAvailable(_wrappedElement)
                    ? _wrappedElement
                    : NullWebElement.Instance;
            }
            private set
            {
                _wrappedElement = value;
            }
        }

        private static bool IsAvailable(IWebElement element)
        {
            try
            {
                var location = element.Location;
                return true;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        }

        internal ISearchContext Context => WrappedElement ?? Driver as ISearchContext;

        public Element(WebDriver driver, IWebElement element, Locator locator, ILifetimeScope scope)
        {
            WrappedElement = element;
            WebDriver = driver;

            Locator = locator;
            _service = new ElementFinderService(scope);
        }

        public IWebDriver Driver => WebDriver.WrappedDriver;

        public string Content => WrappedElement.Text;

        public Point Location => new Point(WrappedElement.Location.X, WrappedElement.Location.Y);

        public Size Size => new Size(WrappedElement.Size.Width, WrappedElement.Size.Height);

        public State State
        {
            get
            {
                var accomulator = State.None;

                if (WrappedElement.Displayed)
                {
                    accomulator |= State.Present;
                }
                else
                {
                    accomulator |= State.Absent;
                }

                if (WrappedElement.Enabled)
                {
                    accomulator |= State.Enabled;
                }
                else
                {
                    accomulator |= State.Disabled;
                }

                return accomulator;
            }
        }

        public Locator Locator { get; set; }

        public string GetAttribute(string attributeName) => WrappedElement.GetAttribute(attributeName);

        public string GetProperty(string propertyName) => WrappedElement.GetProperty(propertyName);

        public string GetCssValue(string cssStyleName) => WrappedElement.GetCssValue(cssStyleName);

        public void Click() => WrappedElement.Click();

        public TElement Find<TElement>(Locator by) where TElement : IElement => _service.Find<TElement>(this, by);

        public IEnumerable<TElement> FindAll<TElement>(Locator by) where TElement : IElement => _service.FindAll<TElement>(this, by);
    }
}

namespace QAutomation.Selenium.Controls
{
    using global::Unity;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Internal;
    using QAutomation.Core;
    using QAutomation.Core.Interfaces.Controls;

    public class Element : IWrapsElement, IElement
    {
        public WebDriver WebDriver;

        private readonly ElementFinderService _service;

        public IWebElement WrappedElement { get; }

        internal ISearchContext Context => this.WrappedElement ?? this.Driver as ISearchContext;

        public Element(WebDriver driver, IWebElement element, Locator locator, IUnityContainer container)
        {
            WrappedElement = element;
            WebDriver = driver;

            Locator = locator;
            _service = new ElementFinderService(container);
        }

        public IWebDriver Driver => this.WebDriver.WrappedDriver;

        public string Content => this.WrappedElement.Text;

        public Point Location => new Point(this.WrappedElement.Location.X, this.WrappedElement.Location.Y);

        public Size Size => new Size(this.WrappedElement.Size.Width, this.WrappedElement.Size.Height);

        public State State
        {
            get
            {
                var accomulator = State.None;

                if (this.WrappedElement.Displayed)
                    accomulator |= State.Present;
                else
                    accomulator |= State.Absent;

                if (this.WrappedElement.Enabled)
                    accomulator |= State.Enabled;
                else
                    accomulator |= State.Disabled;

                return accomulator;
            }
        }

        public Locator Locator { get; set; }

        public string GetAttribute(string attributeName) => this.WrappedElement.GetAttribute(attributeName);
        public string GetProperty(string propertyName) => this.WrappedElement.GetProperty(propertyName);
        public string GetCssValue(string cssStyleName) => this.WrappedElement.GetCssValue(cssStyleName);

        public void Click() => this.WrappedElement.Click();
    }
}

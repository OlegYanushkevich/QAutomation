namespace QAutomation.Selenium
{
    using OpenQA.Selenium;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Drawing;

    public class NullWebElement : IWebElement
    {
        private const string _placeholder = "NULL";

        private static NullWebElement _instance;

        public static NullWebElement Instance
        {
            get
            {
                return _instance ?? (_instance = new NullWebElement());
            }
        }

        protected NullWebElement() { }

        public string TagName => _placeholder;

        public string Text => _placeholder;

        public bool Enabled => false;

        public bool Selected => false;

        public Point Location { get; } = new Point(-1, -1);

        public Size Size { get; } = new Size(-1, -1);

        public bool Displayed => false;

        public virtual void Clear() { }

        public virtual void Click() { }

        public IWebElement FindElement(By by) => this;

        public ReadOnlyCollection<IWebElement> FindElements(By by)
            => new ReadOnlyCollection<IWebElement>(new List<IWebElement>());

        public string GetAttribute(string attributeName) => _placeholder;

        public string GetCssValue(string propertyName) => _placeholder;

        public string GetProperty(string propertyName) => _placeholder;

        public virtual void SendKeys(string text) { }

        public virtual void Submit() { }
    }
}

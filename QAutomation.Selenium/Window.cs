namespace QAutomation.Selenium
{
    using OpenQA.Selenium;
    using QAutomation.Core;
    using System;

    public class Window : Core.Interfaces.IWindow
    {
        private readonly IWebDriver _driver;

        public Window(IWebDriver driver)
        {
            _driver = driver;
        }

        public Uri Url => new Uri(_driver.Url);

        public string Handle => _driver.CurrentWindowHandle;
        public string Title => _driver.Title;

        public string Source => _driver.PageSource;

        public Size Size
        {
            get => new Size(_driver.Manage().Window.Size.Width, _driver.Manage().Window.Size.Width);
            set => _driver.Manage().Window.Size = new System.Drawing.Size(value.Width, value.Height);
        }

        public Point Position
        {
            get
            {
                var location = _driver.Manage().Window.Position;
                return new Point(location.X, location.Y);
            }
            set
            {
                _driver.Manage().Window.Position = new System.Drawing.Point(value.X, value.Y);
            }
        }

        public Core.Interfaces.IWindow FullScreen()
        {
            _driver.Manage().Window.FullScreen();
            return this;
        }
        public Core.Interfaces.IWindow Maximize()
        {
            _driver.Manage().Window.Maximize();
            return this;
        }
        public Core.Interfaces.IWindow Minimize()
        {
            _driver.Manage().Window.Minimize();
            return this;
        }
    }
}

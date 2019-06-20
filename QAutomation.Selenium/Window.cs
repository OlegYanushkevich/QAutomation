namespace QAutomation.Selenium
{
    using OpenQA.Selenium;
    using QAutomation.Core;
    using System;

    public class Window : Core.Interfaces.IWindow
    {
        private readonly IWebDriver driver;

        public Window(IWebDriver driver) => this.driver = driver;

        public Uri Url => new Uri(driver.Url);

        public string Handle => driver.CurrentWindowHandle;

        public string Title => driver.Title;

        public string Source => driver.PageSource;

        public Size Size
        {
            get => new Size(driver.Manage().Window.Size.Width, driver.Manage().Window.Size.Width);
            set => driver.Manage().Window.Size = new System.Drawing.Size(value.Width, value.Height);
        }

        public Point Position
        {
            get
            {
                var location = driver.Manage().Window.Position;
                return new Point(location.X, location.Y);
            }
            set => driver.Manage().Window.Position = new System.Drawing.Point(value.X, value.Y);
        }

        public Core.Interfaces.IWindow FullScreen()
        {
            driver
                .Manage()
                .Window
                .FullScreen();

            return this;
        }

        public Core.Interfaces.IWindow Maximize()
        {
            driver
                .Manage()
                .Window
                .Maximize();

            return this;
        }

        public Core.Interfaces.IWindow Minimize()
        {
            driver
                .Manage()
                .Window
                .Minimize();

            return this;
        }
    }
}

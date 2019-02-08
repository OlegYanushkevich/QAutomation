namespace QAutomation.Selenium
{
    using System;
    using OpenQA.Selenium;
    using QAutomation.Core;

    public class Window : Core.Interfaces.IWindow
    {
        private readonly IWebDriver driver;

        public Window(IWebDriver driver)
        {
            this.driver = driver;
        }

        public Uri Url => new Uri(this.driver.Url);

        public string Handle => this.driver.CurrentWindowHandle;

        public string Title => this.driver.Title;

        public string Source => this.driver.PageSource;

        public Size Size
        {
            get => new Size(this.driver.Manage().Window.Size.Width, this.driver.Manage().Window.Size.Width);
            set => this.driver.Manage().Window.Size = new System.Drawing.Size(value.Width, value.Height);
        }

        public Point Position
        {
            get
            {
                var location = this.driver.Manage().Window.Position;
                return new Point(location.X, location.Y);
            }
            set
            {
                this.driver.Manage().Window.Position = new System.Drawing.Point(value.X, value.Y);
            }
        }

        public Core.Interfaces.IWindow FullScreen()
        {
            this.driver
                .Manage()
                .Window
                .FullScreen();

            return this;
        }

        public Core.Interfaces.IWindow Maximize()
        {
            this.driver
                .Manage()
                .Window
                .Maximize();

            return this;
        }

        public Core.Interfaces.IWindow Minimize()
        {
            this.driver
                .Manage()
                .Window
                .Minimize();

            return this;
        }
    }
}

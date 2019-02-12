namespace QAutomation.Selenium.Logged
{
    using OpenQA.Selenium;
    using QAutomation.AspectInjector;
    using System.Drawing;

    [Logged]
    public class LoggedWindow : IWindow
    {
        private readonly IWindow decoratedWindow;

        public LoggedWindow(IWindow decoratedWindow)
        {
            this.decoratedWindow = decoratedWindow;
        }

        public Point Position
        {
            get => this.decoratedWindow.Position;
            set => this.decoratedWindow.Position = value;
        }

        public Size Size
        {
            get => this.decoratedWindow.Size;
            set => this.decoratedWindow.Size = value;
        }

        public void FullScreen() => this.decoratedWindow.FullScreen();

        public void Maximize() => this.decoratedWindow.Maximize();

        public void Minimize() => this.decoratedWindow.Minimize();
    }
}

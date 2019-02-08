namespace QAutomation.Core.Interfaces
{
    using System;

    public interface IWindow
    {
        Uri Url { get; }

        string Handle { get; }

        string Title { get; }

        string Source { get; }

        Size Size { get; set; }

        Point Position { get; set; }

        IWindow Maximize();

        IWindow Minimize();

        IWindow FullScreen();
    }
}

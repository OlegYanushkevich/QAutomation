﻿namespace QAutomation.Core.Interfaces
{
    using QAutomation.Core.Interfaces.Controls;

    public interface ITargetLocatorService
    {
        IAlert Alert();
        IWindow Window(string handle);
        IDriver DefaultContent();
        IDriver Frame(By by);
    }
}

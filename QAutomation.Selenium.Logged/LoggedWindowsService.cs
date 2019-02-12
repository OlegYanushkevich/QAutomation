namespace QAutomation.Selenium.Logged
{
    using System;
    using System.Collections.Generic;
    using QAutomation.Core.Interfaces;

    public class LoggedWindowsService : IWindowsService
    {
        private readonly IWindowsService decoratedWindowsService;

        public LoggedWindowsService(IWindowsService decoratedWindowsService)
        {
            this.decoratedWindowsService = decoratedWindowsService ?? throw new NullReferenceException(nameof(decoratedWindowsService));
        }

        public IWindow Current => this.decoratedWindowsService.Current;

        public IReadOnlyCollection<string> Handles => this.decoratedWindowsService.Handles;

        public IWindow CloseCurrentWindow() => decoratedWindowsService.CloseCurrentWindow();

        public IWindow SwitchToLastWindow() => this.decoratedWindowsService.SwitchToLastWindow();

        public IWindow SwitchToWindow(string handle) => this.decoratedWindowsService.SwitchToWindow(handle);
    }
}

namespace QAutomation.Selenium.Logged
{
    using QAutomation.AspectInjector;
    using QAutomation.Core;
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;
    using System;

    [Logged]
    public class LoggedTargetLocatorService : ITargetLocatorService
    {
        private readonly ITargetLocatorService decoratedTargetLocatorService;

        public LoggedTargetLocatorService(ITargetLocatorService targetLocatorService)
        {
            decoratedTargetLocatorService = targetLocatorService ?? throw new NullReferenceException(nameof(targetLocatorService));
        }

        public IAlert Alert() => this.decoratedTargetLocatorService.Alert();

        public IDriver DefaultContent() => this.decoratedTargetLocatorService.DefaultContent();

        public IDriver Frame(Locator by) => this.decoratedTargetLocatorService.Frame(by);


        public IDriver Frame(IFrameElement frame) => this.decoratedTargetLocatorService.Frame(frame);

        public IWindow Window(string handle) => this.decoratedTargetLocatorService.Window(handle);
    }
}

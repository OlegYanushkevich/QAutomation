namespace QAutomation.Selenium.Logged
{
    using QAutomation.AspectInjector;
    using QAutomation.Core.Interfaces;
    using System;

    [Logged]
    public class LoggedNavigationService : INavigationService
    {
        private readonly INavigationService navigationService;

        public LoggedNavigationService(INavigationService navigationService)
        {
            this.navigationService = navigationService ?? throw new NullReferenceException(nameof(navigationService));
        }

        public void Back() => this.navigationService.Back();

        public void Forward() => this.navigationService.Forward();

        public void Refresh() => this.navigationService.Refresh();

        public INavigationService Url(string url) => this.navigationService.Url(url);
    }
}

namespace QAutomation.Selenium
{
    using QAutomation.Core.Interfaces;
    using System;

    public class ManageOptionsService : IManageOptions
    {
        private readonly ICookiesService cookiesService;
        private readonly IWindowsService windowsService;

        public ManageOptionsService(ICookiesService cookiesService, IWindowsService windowsService)
        {
            this.cookiesService = cookiesService ?? throw new NullReferenceException(nameof(cookiesService));
            this.windowsService = windowsService ?? throw new NullReferenceException(nameof(windowsService));
        }

        public ICookiesService Cookies() => this.cookiesService;
        public IWindowsService Windows() => this.windowsService;
    }
}

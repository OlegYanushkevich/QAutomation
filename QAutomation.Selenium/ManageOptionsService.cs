namespace QAutomation.Selenium
{
    using QAutomation.Core.Interfaces;

    public class ManageOptionsService : IManageOptions
    {
        private readonly ICookiesService cookiesService;
        private readonly IWindowsService windowsService;

        public ManageOptionsService(ICookiesService cookiesService, IWindowsService windowsService)
        {
            this.cookiesService = cookiesService;
            this.windowsService = windowsService;
        }

        public ICookiesService Cookies() => this.cookiesService;
        public IWindowsService Windows() => this.windowsService;
    }
}

namespace QAutomation.Selenium
{
    using QAutomation.Core.Interfaces;

    public class ManageOptionsService : IManageOptions
    {
        private readonly ICookiesService _cookieService;
        private readonly IWindowsService _windowsService;

        public ManageOptionsService(ICookiesService cookiesService, IWindowsService windowsService)
        {
            _cookieService = cookiesService;
            _windowsService = windowsService;
        }

        public ICookiesService Cookies() => _cookieService;
        public IWindowsService Windows() => _windowsService;
    }
}

namespace QAutomation.Selenium
{
    using QAutomation.Core.Interfaces;
    using System;

    public class ManageOptionsService : IManageOptions
    {
        private readonly ICookiesService _cookiesService;
        private readonly IWindowsService _windowsService;

        public ManageOptionsService(ICookiesService cookiesService, IWindowsService windowsService)
        {
            _cookiesService = cookiesService ?? throw new NullReferenceException(nameof(cookiesService));
            _windowsService = windowsService ?? throw new NullReferenceException(nameof(windowsService));
        }

        public ICookiesService Cookies() => _cookiesService;

        public IWindowsService Windows() => _windowsService;
    }
}

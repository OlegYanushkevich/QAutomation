namespace QAutomation.Selenium
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces;

    public class ManageOptionsService : IManageOptions
    {
        private readonly CookiesService _cookieService;
        private readonly WindowsService _windowsService;

        public ManageOptionsService(IWebDriver driver)
        {
            _cookieService = new CookiesService(driver.Manage().Cookies);
            _windowsService = new WindowsService(driver);
        }

        public ICookiesService Cookies() => _cookieService;
        public IWindowsService Windows() => _windowsService;
    }
}

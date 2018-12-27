namespace QAutomation.Selenium
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces;

    public class ManageOptionsService : IManageOptions
    {
        private readonly CookieService _cookieService;
        private readonly WindowsService _windowsService;

        public ManageOptionsService(IWebDriver driver)
        {
            _cookieService = new CookieService(driver.Manage().Cookies);
            _windowsService = new WindowsService(driver);
        }

        public ICookieService Cookies() => _cookieService;
        public IWindowService Windows() => _windowsService;
    }
}

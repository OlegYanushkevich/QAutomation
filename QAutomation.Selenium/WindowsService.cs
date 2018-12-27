namespace QAutomation.Selenium
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces;
    using System.Collections.Generic;

    public class WindowsService : IWindowService
    {

        private readonly Core.Interfaces.IWindow _current;
        private readonly IWebDriver _driver;

        public WindowsService(IWebDriver driver)
        {
            _driver = driver;
            _current = new Window(_driver);
        }

        public Core.Interfaces.IWindow Current => _current;

        public IReadOnlyCollection<string> Handles => _driver.WindowHandles;
    }
}

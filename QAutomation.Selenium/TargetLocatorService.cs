namespace QAutomation.Selenium
{
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Selenium.Controls;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TargetLocatorService : ITargetLocatorService
    {
        private readonly WebDriver _driver;

        public TargetLocatorService(WebDriver driver)
        {
            _driver = driver;
        }

        public IAlert Alert() => new Alert(_driver.Driver.SwitchTo().Alert());


        public IDriver DefaultContent()
        {
            if (_driver.CurrentFrame != null)
            {
                _driver.SwitchTo().DefaultContent();
                _driver.CurrentFrame = null;
            }

            return _driver;
        }

        public IDriver Frame(Core.By by)
        {
            var frame = _driver.Find<FrameElement>(by);
            _driver.Driver.SwitchTo().Frame(frame.WrappedElement);

            _driver.CurrentFrame = frame;
            return _driver;
        }


        public IWindow Window(string handle)
        {
            _driver.Driver.SwitchTo().Window(handle);
            return _driver.Manage().Windows().Current;
        }
    }
}

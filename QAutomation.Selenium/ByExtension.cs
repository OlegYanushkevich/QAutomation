namespace QAutomation.Selenium
{
    using OpenQA.Selenium;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class ByExtension
    {
        public static By Cast(this Core.By by)
        {
            switch (by.Type)
            {
                case Core.LocatorType.Xpath:
                    return By.XPath(by.Value);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
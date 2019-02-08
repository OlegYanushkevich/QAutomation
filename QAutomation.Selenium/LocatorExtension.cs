namespace QAutomation.Selenium
{
    using OpenQA.Selenium;
    using System;

    public static class LocatorExtension
    {
        public static By Cast(this Core.Locator by)
        {
            switch (by.Type)
            {
                case Core.LocatorType.Xpath:
                    return By.XPath(by.Value);
                case Core.LocatorType.CssSeletor:
                    return By.CssSelector(by.Value);
                case Core.LocatorType.Id:
                    return By.Id(by.Value);
                case Core.LocatorType.Name:
                    return By.Name(by.Value);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
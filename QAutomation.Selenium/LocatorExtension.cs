namespace QAutomation.Selenium
{
    using OpenQA.Selenium;
    using System;

    public static class LocatorExtension
    {
        public static By Cast(this Core.Locator locator)
        {
            switch (locator.Type)
            {
                case Core.LocatorType.Xpath:
                    return By.XPath(locator.Value);
                case Core.LocatorType.CssSeletor:
                    return By.CssSelector(locator.Value);
                case Core.LocatorType.Id:
                    return By.Id(locator.Value);
                case Core.LocatorType.Name:
                    return By.Name(locator.Value);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
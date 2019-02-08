namespace QAutomation.Core
{
    public struct Locator
    {
        public string Value { get; set; }
        public LocatorType Type { get; set; }

        public Locator(LocatorType type, string value)
        {
            Value = value;
            Type = type;
        }

        public static Locator XPath(string value) => new Locator(LocatorType.Xpath, value);

        public static Locator CssSelector(string value) => new Locator(LocatorType.CssSeletor, value);

        public static Locator Id(string value) => new Locator(LocatorType.Id, value);

        public static Locator Name(string value) => new Locator(LocatorType.Name, value);
    }
}
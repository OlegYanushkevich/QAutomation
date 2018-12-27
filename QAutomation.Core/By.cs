namespace QAutomation.Core
{
    public struct By
    {
        public string Value { get; set; }
        public LocatorType Type { get; set; }

        public By(LocatorType type, string value)
        {
            Value = value;
            Type = type;
        }
    }
}
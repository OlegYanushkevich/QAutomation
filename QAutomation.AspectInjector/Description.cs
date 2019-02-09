namespace QAutomation.AspectInjector
{
    using QAutomation.Logging.Abstract;
    using System;

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property)]
    public class DescriptionAttribute : Attribute
    {
        public string Description { get; set; }
        public LogLevel Level { get; set; }

        public DescriptionAttribute(string description, LogLevel level)
        {
            this.Description = description;
            this.Level = level;
        }
    }
}

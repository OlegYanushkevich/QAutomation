namespace QAutomation.Core.Interfaces
{
    using System;

    public interface IDriverConfig
    {
        TimeSpan SearchTimeout { get; set; }

        TimeSpan PollingInterval { get; set; }
    }
}

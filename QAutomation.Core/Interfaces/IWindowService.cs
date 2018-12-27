namespace QAutomation.Core.Interfaces
{
    using System.Collections.Generic;

    public interface IWindowService
    {
        IWindow Current { get; }
        IReadOnlyCollection<string> Handles { get; }
    }
}

namespace QAutomation.Core.Interfaces
{
    using System.Collections.Generic;

    public interface IWindowsService
    {
        IWindow Current { get; }
        IReadOnlyCollection<string> Handles { get; }
    }
}

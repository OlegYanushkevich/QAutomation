namespace QAutomation.Core.Interfaces
{
    using QAutomation.Core.Interfaces.Controls;
    using System.Collections.Generic;

    public interface IElementFinderService
    {
        TElement Find<TElement>(Locator by) where TElement : IElement;
        IEnumerable<TElement> FindAll<TElement>(Locator by) where TElement : IElement;
    }
}

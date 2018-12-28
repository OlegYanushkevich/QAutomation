namespace QAutomation.Core.Interfaces
{
    using QAutomation.Core.Interfaces.Controls;
    using System.Collections.Generic;

    public interface IElementFinderService
    {
        TElement Find<TElement>(By by) where TElement : IElement;
        IEnumerable<TElement> FindAll<TElement>(By by) where TElement : IElement;
    }
}

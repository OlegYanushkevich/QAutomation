namespace QAutomation.Core.Interfaces.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ITextElement : IElement
    {
        void SendKeys(string text);
    }
}

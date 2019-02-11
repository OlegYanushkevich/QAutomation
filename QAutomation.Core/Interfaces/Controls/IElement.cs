namespace QAutomation.Core.Interfaces.Controls
{
    public interface IElement
    {
        Locator Locator { get; set; }

        string Content { get; }

        Point Location { get; }

        Size Size { get; }

        State State { get; }

        void Click();

        string GetAttribute(string attributeName);

        string GetProperty(string propertyName);

        string GetCssValue(string cssStyleName);
    }
}

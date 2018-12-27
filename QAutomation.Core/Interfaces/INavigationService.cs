namespace QAutomation.Core.Interfaces
{
    public interface INavigationService
    {
        INavigationService Url(string url);

        void Back();
        void Refresh();
        void Forward();
    }
}

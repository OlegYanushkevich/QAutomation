namespace QAutomation.Selenium
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces;

    public class NavigationService : INavigationService
    {
        private readonly INavigation _navigation;

        public NavigationService(INavigation navigation)
        {
            _navigation = navigation;
        }

        public void Back() => _navigation.Back();
        public void Forward() => _navigation.Forward();
        public void Refresh() => _navigation.Refresh();

        public INavigationService Url(string url)
        {
            _navigation.GoToUrl(url);
            return this;
        }
    }
}

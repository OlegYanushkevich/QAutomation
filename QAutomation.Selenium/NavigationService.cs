namespace QAutomation.Selenium
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces;

    public class NavigationService : INavigationService
    {
        private readonly INavigation navigation;

        public NavigationService(INavigation navigation)
        {
            this.navigation = navigation;
        }

        public void Back() => this.navigation.Back();
        public void Forward() => this.navigation.Forward();
        public void Refresh() => this.navigation.Refresh();

        public INavigationService Url(string url)
        {
            this.navigation.GoToUrl(url);
            return this;
        }
    }
}

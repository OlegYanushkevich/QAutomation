namespace QAutomation.Core.Interfaces
{
    public interface IDriver : IElementFinderService, IJavaScriptExecutor
    {
        IDriverConfig Config { get; }

        IManageOptions Manage();
        ITargetLocatorService SwitchTo();
        INavigationService Navigate();

        IWaitingService Wait();

        void Quit();
    }
}
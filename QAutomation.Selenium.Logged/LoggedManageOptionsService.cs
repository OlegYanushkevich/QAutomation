namespace QAutomation.Selenium.Logged
{
    using System;
    using QAutomation.AspectInjector;
    using QAutomation.Core.Interfaces;

    [Logged]
    public class LoggedManageOptionsService : IManageOptions
    {
        private readonly IManageOptions decoratedManageOptions;

        public LoggedManageOptionsService(IManageOptions decoratedManageOptions)
        {
            this.decoratedManageOptions = decoratedManageOptions ?? throw new NullReferenceException(nameof(decoratedManageOptions));
        }

        public ICookiesService Cookies() => this.decoratedManageOptions.Cookies();

        public IWindowsService Windows() => this.decoratedManageOptions.Windows();
    }
}

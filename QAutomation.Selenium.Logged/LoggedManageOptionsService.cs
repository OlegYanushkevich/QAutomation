namespace QAutomation.Selenium.Logged
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using QAutomation.AspectInjector;
    using QAutomation.Core.Interfaces;

    [Logged]
    public class LoggedManageOptionsService : ManageOptionsService
    {
        public LoggedManageOptionsService(ICookiesService cookiesService, IWindowsService windowsService) 
            : base(cookiesService, windowsService) { }
    }
}

//-----------------------------------------------------------------------
// <copyright file="WindowsService.cs" company="EPAM">
//     Copyright (c) EPAM Systems Inc. All rights reserved.
// </copyright>
// <author>Oleg Yanushkevich</author>
//----------------
namespace QAutomation.Selenium
{
    using Autofac;
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Service for managing browser windows
    /// </summary>
    public class WindowsService : IWindowsService
    {
        /// <summary>
        /// Field that contains <see cref="IWebDriver"/> instance
        /// </summary>
        private readonly IWebDriver _driver;

        private readonly ILifetimeScope _scope;

        private Core.Interfaces.IWindow _current;

        /// <summary>
        /// Gets current browser window
        /// </summary>
        public Core.Interfaces.IWindow Current => _current ?? (_current = _scope.Resolve<Core.Interfaces.IWindow>(new TypedParameter(typeof(IWebDriver), _driver)));

        /// <summary>
        /// Contains all windows handless
        /// </summary>
        public IReadOnlyCollection<string> Handles => _driver.WindowHandles;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowsService"/> class.
        /// </summary>
        /// <param name="driver">instance of web driver</param>
        public WindowsService(IWebDriver driver, ILifetimeScope scope)
        {
            _driver = driver;
            _scope = scope;
        }

        public Core.Interfaces.IWindow SwitchToLastWindow() => SwitchToWindow(Handles.Last());

        public Core.Interfaces.IWindow SwitchToWindow(string handle)
        {
            _driver.SwitchTo().Window(handle);
            return Current;
        }

        public Core.Interfaces.IWindow CloseCurrentWindow()
        {
            if (Handles.Count > 1)
            {
                _driver.Close();
                return SwitchToLastWindow();
            }
            _driver.Close();
            return null;
        }
    }
}

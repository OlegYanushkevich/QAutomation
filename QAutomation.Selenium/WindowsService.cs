//-----------------------------------------------------------------------
// <copyright file="WindowsService.cs" company="EPAM">
//     Copyright (c) EPAM Systems Inc. All rights reserved.
// </copyright>
// <author>Oleg Yanushkevich</author>
//----------------
namespace QAutomation.Selenium
{
    using System.Collections.Generic;
    using System.Linq;
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces;
    using Unity;
    using Unity.Resolution;

    /// <summary>
    /// Service for managing browser windows
    /// </summary>
    public class WindowsService : IWindowsService
    {
        /// <summary>
        /// Field that contains <see cref="IWebDriver"/> instance
        /// </summary>
        private readonly IWebDriver driver;

        private readonly IUnityContainer container;

        private Core.Interfaces.IWindow current;

        /// <summary>
        /// Gets current browser window
        /// </summary>
        public Core.Interfaces.IWindow Current
        {
            get => current ?? (current = this.container.Resolve<Core.Interfaces.IWindow>(new ParameterOverride(nameof(driver), driver)));
        }

        /// <summary>
        /// Contains all windows handless
        /// </summary>
        public IReadOnlyCollection<string> Handles => this.driver.WindowHandles;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowsService"/> class.
        /// </summary>
        /// <param name="driver">instance of web driver</param>
        public WindowsService(IWebDriver driver, IUnityContainer container)
        {
            this.driver = driver;
            this.container = container;
        }

        public Core.Interfaces.IWindow SwitchToLastWindow() => this.SwitchToWindow(Handles.Last());

        public Core.Interfaces.IWindow SwitchToWindow(string handle)
        {
            driver.SwitchTo().Window(handle);
            return Current;
        }

        public Core.Interfaces.IWindow CloseCurrentWindow()
        {
            if (this.Handles.Count > 1)
            {
                this.driver.Close();
                return this.SwitchToLastWindow();
            }
            this.driver.Close();
            return null;
        }

    }
}

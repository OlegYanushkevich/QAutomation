//-----------------------------------------------------------------------
// <copyright file="WindowsService.cs" company="EPAM">
//     Copyright (c) EPAM Systems Inc. All rights reserved.
// </copyright>
// <author>Oleg Yanushkevich</author>
//----------------
namespace QAutomation.Selenium
{
    using System.Collections.Generic;
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces;

    /// <summary>
    /// Service for managing browser windows
    /// </summary>
    public class WindowsService : IWindowsService
    {
        /// <summary>
        /// Field that contains <see cref="IWebDriver"/> instance
        /// </summary>
        private readonly IWebDriver driver;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowsService"/> class.
        /// </summary>
        /// <param name="driver">instance of web driver</param>
        public WindowsService(IWebDriver driver)
        {
            this.driver = driver;
            this.Current = new Window(this.driver);
        }

        /// <summary>
        /// Gets current browser window
        /// </summary>
        public Core.Interfaces.IWindow Current { get; }

        /// <summary>
        /// Contains all windows handless
        /// </summary>
        public IReadOnlyCollection<string> Handles => this.driver.WindowHandles;
    }
}

//-----------------------------------------------------------------------
// <copyright file="ChromeWebDriverConfig.cs" company="EPAM">
//     Copyright (c) EPAM Systems Inc. All rights reserved.
// </copyright>
// <author>Oleg Yanushkevich</author>
//----------------
namespace QAutomation.Selenium.Configs
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Chrome web driver configuration
    /// </summary>
    public class ChromeWebDriverConfig : WebDriverConfig
    {
        /// <summary>
        /// Gets chrome options
        /// </summary>
        public ChromeOptions Options
        {
            get
            {
                ChromeOptions options = new ChromeOptions();

                options.AddUserProfilePreference("download.prompt_for_download", true);
                options.AddUserProfilePreference("download.default_directory", "NULL");
                options.AddUserProfilePreference("profile.default_content_setting_values.notifications", 2);
                options.AddArgument("disable-infobars");
                options.AddArgument("disable-blink-features=BlockCredentialedSubresources");

                options.Proxy = this.GetProxy();
                return options;
            }
        }

        /// <summary>
        /// Create a instance of the <see cref="IWebDriver"/> interface that will be started locally
        /// </summary>
        /// <returns><see cref="IWebDriver"/></returns>
        public override IWebDriver CreateLocalDriver()
        {
            ChromeDriverService driverService;
            string path = Environment.GetEnvironmentVariable("webdriver.chrome.driver", EnvironmentVariableTarget.Machine);

            driverService = path != null
                ? ChromeDriverService.CreateDefaultService(path)
                : ChromeDriverService.CreateDefaultService();

            driverService.HideCommandPromptWindow = true;

            var driver = new ChromeDriver(driverService, this.Options, this.CommandTimeout);
            this.ProcessId = driverService.ProcessId;

            return driver;
        }

        /// <summary>
        /// Configuration and getting new instance of the <see cref="IWebDriver"/> interface that will be started remotely
        /// </summary>
        /// <returns><see cref="IWebDriver"/></returns>
        public override IWebDriver CreateRemoteDriver() => new RemoteWebDriver(new Uri(GridUri), this.Options.ToCapabilities(), CommandTimeout);
    }
}

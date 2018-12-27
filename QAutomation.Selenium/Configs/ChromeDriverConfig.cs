namespace QAutomation.Selenium.Configs
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Remote;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ChromeWebDriverConfig : WebDriverConfig
    {
        public ChromeWebDriverConfig() { }


        public override IWebDriver CreateLocalDriver()
        {
            ChromeDriverService driverService;
            string path = Environment.GetEnvironmentVariable("webdriver.chrome.driver", EnvironmentVariableTarget.Machine);
            if (path != null)
                driverService = ChromeDriverService.CreateDefaultService(path);
            else
                driverService = ChromeDriverService.CreateDefaultService();

            driverService.EnableVerboseLogging = true;
            driverService.HideCommandPromptWindow = true;

            var driver = new ChromeDriver(driverService, Options, CommandTimeout);
            ProcessID = driverService.ProcessId;
            return driver;
        }
        public override IWebDriver CreateRemoteDriver()
        {
            return new RemoteWebDriver(new Uri(GridUri), Options.ToCapabilities(), CommandTimeout);
        }

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

                options.Proxy = GetProxy();
                return options;
            }
        }
    }
}

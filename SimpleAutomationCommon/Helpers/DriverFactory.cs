namespace SimpleAutomationCommon.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Threading;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.Remote;

    public class DriverFactory
    {
        private readonly Browser _browserName = ConfigurationHelper.Browser;

        public bool IsCreated { get; private set; }

        private static readonly ThreadLocal<DriverFactory> Instance =
            new ThreadLocal<DriverFactory>(() => new DriverFactory());

        public IWebDriver DriverInstanse { get; private set; }

        public static DriverFactory GetDriverInstance()
        {
            return Instance.Value;
        }

        public void StartBrowser()
        {
            var browserParameters = Environment.GetEnvironmentVariable("browser");
            var selenoidHub = Environment.GetEnvironmentVariable("selenoidHub");
            var mainUrl = Environment.GetEnvironmentVariable("simplCommerceEndpoint") ?? ConfigurationHelper.MainUrl;
            var optionArguments = Environment.GetEnvironmentVariable("optionArguments");

            if (browserParameters != null && selenoidHub != null)
            {
                var browserCaps = browserParameters.Split('_').ToList();
                var options = new ChromeOptions();
                options.AddUserProfilePreference("credentials_enable_service", false);  // for disabling saving passwords notification
                options.AddArguments(optionArguments.Split(';'));
                var capabilities = options.ToCapabilities() as DesiredCapabilities;
                capabilities.Platform = new Platform(PlatformType.Any);
                capabilities.SetCapability("enableVNC", true);
                capabilities.SetCapability(CapabilityType.BrowserName, browserCaps[0]);
                capabilities.SetCapability(CapabilityType.Version, browserCaps[1]);

                DriverInstanse = new RemoteWebDriver(new Uri(selenoidHub), capabilities);
                #region CapabilitiesStaff
                //capabilities.SetCapability("screenResolution", "1920x1080x24");
                //                capabilities.SetCapability(RemoteWebDriverCapability.EnableVnc, true);
                //                capabilities.SetCapability(RemoteWebDriverCapability.EnableVideo, true);
                //                capabilities.SetCapability(RemoteWebDriverCapability.VideoFileName, TestRunData.TestName + Constants.Test.FileFormats.Mp4);
                //                capabilities.SetCapability(RemoteWebDriverCapability.Name, TestRunConstants.TestSuiteName);
                #endregion
            }
            else
            {
                switch (_browserName)
                {
                    case Browser.Chrome:
                        var options = new ChromeOptions();
                        options.AddUserProfilePreference("credentials_enable_service", false);  // for disabling saving passwords notification
                        options.AddArgument("disable-infobars");    // for disabling infobar "Chrome is being controlled by automated software";
                        options.AddArgument("start-maximized");
                        options.AddArgument($"--homepage={mainUrl}");
                        DriverInstanse = new ChromeDriver(options);
                        break;
                    case Browser.Ie:
                        DriverInstanse = new InternetExplorerDriver();
                        break;
                    case Browser.Firefox:
                        DriverInstanse = new FirefoxDriver();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"No such browser registred as:{_browserName}");
                }
            }

            IsCreated = true;
            var defaultTimeOut = ConfigurationHelper.ElementTimeOut;
            DriverInstanse.Manage().Window.Size = new Size(1920, 1080);
            DriverInstanse.Manage().Timeouts().ImplicitWait = defaultTimeOut;
        }

        public void StopBrowser()
        {
            DriverInstanse.Quit();
            DriverInstanse = null;
        }

        public void GoToUrl(string path)
            => DriverInstanse.Navigate().GoToUrl(path);

        public string GetUrl()
            => DriverInstanse.Url;

//        public void ExecuteScript(string script, params object[] parameters)
//            => DriverInstanse.ExecuteJavaScript(script, parameters);
//
//        public T ExecuteScript<T>(string script, params object[] parameters)
//            => DriverInstanse.ExecuteJavaScript<T>(script, parameters);
//
//        public void TakeScreenshot(string fileName)
//            => DriverInstanse.TakeScreenshot().SaveAsFile(fileName, ScreenshotImageFormat.Png);

        public IEnumerable<LogEntry> GetLogsBrowser()
            => DriverInstanse.Manage().Logs.GetLog(LogType.Browser);

        public void Refresh()
            => DriverInstanse.Navigate().Refresh();
    }
}

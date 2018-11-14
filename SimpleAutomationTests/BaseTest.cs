using System;
using System.Linq;
using Atata;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using SimpleAutomationCommon.DataModels.Enums;
using SimpleAutomationCommon.Helpers;

namespace SimpleAutomationTests
{
    public class BaseTest
    {
        private AtataContextBuilder _contextBuilder;

        [OneTimeSetUp]
        protected void GeneralSetUp()
        {
            _contextBuilder = AtataContext.Configure();
        }

        [SetUp]
        protected void SetUp()
        {
            StartBrowser();
            _contextBuilder.Build();
            AtataContext.Current.Driver.Maximize();
        }

        [TearDown]
        protected void TearDown()
        {
            AtataContext.Current?.CleanUp();
        }

        [OneTimeTearDown]
        protected void GeneralTearDown()
        {
            AtataContext.Current?.CleanUp();
        }

        private void StartBrowser()
        {
            var browserParameters = Environment.GetEnvironmentVariable("browser");
            var selenoidHub = Environment.GetEnvironmentVariable("selenoidHub");
            var mainUrl = Environment.GetEnvironmentVariable("simplCommerceEndpoint") ?? ConfigurationHelper.MainUrl;
            var optionArguments = Environment.GetEnvironmentVariable("optionArguments");

            if (browserParameters != null && selenoidHub != null)
            {
                var browserCaps = browserParameters.Split('_').ToList();
                var options = new ChromeOptions();
                options.AddUserProfilePreference(
                    "credentials_enable_service",
                    false); // for disabling saving passwords notification
                options.AddArguments(optionArguments.Split(';'));
                var capabilities = options.ToCapabilities() as DesiredCapabilities;
                capabilities.Platform = new Platform(PlatformType.Any);
                capabilities.SetCapability("enableVNC", ConfigurationHelper.Vnc);
                capabilities.SetCapability("enableVideo", false);
                capabilities.SetCapability("screenResolution", "1920x1080x24");
                capabilities.SetCapability(CapabilityType.BrowserName, browserCaps[0]);
                capabilities.SetCapability(CapabilityType.Version, browserCaps[1]);

                _contextBuilder
                    .UseRemoteDriver()
                    .WithRemoteAddress(new Uri(selenoidHub))
                    .WithCapabilities(capabilities)
                    .TakeScreenshotOnNUnitError()
                    .AddScreenshotFileSaving();
            }
            else
            {
                var browserName = ConfigurationHelper.Browser;
                switch (browserName)
                {
                    case Browser.Chrome:
                        _contextBuilder
                            .UseChrome()
                            .WithFixOfCommandExecutionDelay()
                            .WithArguments("start-maximized", "disable-infobars", "disable-extensions")
                            .WithOptions(x => x.AddUserProfilePreference("credentials_enable_service", false));
                        break;
                    case Browser.Edge:
                        _contextBuilder
                            .UseEdge();
                        break;
                    case Browser.Firefox:
                        _contextBuilder
                            .UseFirefox()
                            .WithFixOfCommandExecutionDelay();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"No such browser registered as:{browserName}");
                }
            }

            _contextBuilder
                .UseBaseUrl(mainUrl)
                .UseElementFindTimeout(ConfigurationHelper.ElementTimeOut)
                .UseWaitingRetryInterval(ConfigurationHelper.RetryTimeOut)
                .UseCulture("en-us")
                .AddNUnitTestContextLogging()
                .TakeScreenshotOnNUnitError()
                .AddScreenshotFileSaving()
                .WithFolderPath(() => $@"ScreenShots\{ConfigurationHelper.ScreenshotsFolderPath}{AtataContext.BuildStart:yyyy-MM-dd HH_mm_ss}")
                .WithFileName(screenshotInfo => $"{AtataContext.Current.TestName} - {screenshotInfo.PageObjectName}");
        }
    }
}
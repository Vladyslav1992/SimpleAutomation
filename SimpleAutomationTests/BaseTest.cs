namespace SimpleAutomationTests
{
    using System;
    using System.Linq;
    using Atata;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Remote;
    using SimpleAutomationCommon.Helpers;

    [TestFixture]
    public class BaseTest
    {
        private AtataContextBuilder contextBuilder;

        [OneTimeSetUp]
        protected void GeneralSetUp()
        {
            contextBuilder = AtataContext.Configure();
        }

        [SetUp]
        protected void SetUp()
        {
            StartBrowser();
            contextBuilder.Build();
        }

        [TearDown]
        protected void TearDown()
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
                capabilities.SetCapability("enableVNC", true);
                capabilities.SetCapability(CapabilityType.BrowserName, browserCaps[0]);
                capabilities.SetCapability(CapabilityType.Version, browserCaps[1]);

                contextBuilder
                    .UseRemoteDriver()
                    .WithRemoteAddress(new Uri(selenoidHub))
                    .WithCapabilities(capabilities)
                    .TakeScreenshotOnNUnitError()
                    .AddScreenshotFileSaving();


                #region CapabilitiesStaff
                // capabilities.SetCapability("screenResolution", "1920x1080x24");
                // capabilities.SetCapability(RemoteWebDriverCapability.EnableVnc, true);
                // capabilities.SetCapability(RemoteWebDriverCapability.EnableVideo, true);
                // capabilities.SetCapability(RemoteWebDriverCapability.VideoFileName, TestRunData.TestName + Constants.Test.FileFormats.Mp4);
                // capabilities.SetCapability(RemoteWebDriverCapability.Name, TestRunConstants.TestSuiteName);

                #endregion
            }
            else
            {
                var browserName = ConfigurationHelper.Browser;
                switch (browserName)
                {
                    case Browser.Chrome:
                        contextBuilder
                            .UseChrome()
                            .WithArguments("start-maximized", "disable-infobars", "disable-extensions")
                            .WithOptions(x => x.AddUserProfilePreference("credentials_enable_service", false));
                        break;
                    case Browser.Ie:
                        contextBuilder.UseEdge();
                        break;
                    case Browser.Firefox:
                        contextBuilder.UseFirefox();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"No such browser registered as:{browserName}");
                }
            }

            contextBuilder
                .UseBaseUrl(mainUrl)
                .UseElementFindTimeout(ConfigurationHelper.ElementTimeOut)
                .UseWaitingRetryInterval(ConfigurationHelper.RetryTimeOut)
                .UseCulture("en-us")
                .UseNUnitTestName()
                .AddNUnitTestContextLogging()
                .LogNUnitError()
                .TakeScreenshotOnNUnitError()
                .AddScreenshotFileSaving();
        }
    }
}
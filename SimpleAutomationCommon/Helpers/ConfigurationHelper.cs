using System;
using System.Linq;
using SimpleAutomationCommon.Helpers.Extensions;

namespace SimpleAutomationCommon.Helpers
{
    public static class ConfigurationHelper
    {
        private static string GetSettings(string settingName)
        {
            var setting = ConfigurationManager.AppSettings[settingName];
            if (setting == null)
                throw new ConfigurationErrorsException($"{settingName} setting is missing");
            return setting;
        }

        public static string MainUrl => Environment.GetEnvironmentVariable("simplCommerceEndpoint") ?? GetSettings("homeUrl");
        public static Browser Browser => Browsers.GetBrowser(GetSettings("browser"));
        public static TimeSpan RetryTimeOut =>
            TimeSpan.FromMilliseconds(GetSettings("retryTimeout").ToInt());
        public static TimeSpan ElementTimeOut =>
            TimeSpan.FromSeconds(GetSettings("elementTimeout").Split(':').Last().ToInt());
    }
}
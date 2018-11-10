namespace SimpleAutomationCommon.Helpers
{
    using System;
    using System.IO;
    using System.Linq;
    using DataModels.Enums;
    using Extensions;
    using Microsoft.Extensions.Configuration;

    public static class ConfigurationHelper
    {
        public static string MainUrl { get; } =
            Environment.GetEnvironmentVariable("simplCommerceEndpoint") ?? GetSettings("App", "homeUrl");

        public static string ScreenshotsFolderPath { get; } =
            Environment.GetEnvironmentVariable("screenShotsFolderPath") ?? string.Empty;

        public static Browser Browser => Enum.Parse<Browser>(GetSettings("Browser", "Name"), true);

        public static bool Vnc =>
            (Environment.GetEnvironmentVariable("vnc") ?? GetSettings("Browser", "Vnc")).Contains("true");

        public static TimeSpan RetryTimeOut =>
            TimeSpan.FromMilliseconds(GetSettings("Browser", "retryTimeout").ToInt());

        public static TimeSpan ElementTimeOut =>
            TimeSpan.FromSeconds(GetSettings("Browser", "elementTimeout").Split(':').Last().ToInt());

        private static string GetSettings(string sectionName, string settingName)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddEnvironmentVariables()
                .Build();

            // .AddJsonFile($"appsettings.{TestEnvironment}.json", optional: true, reloadOnChange: false)
            var setting = configuration.GetSection(sectionName);
            if (setting == null)
            {
                throw new Exception($"{settingName} setting is missing");
            }

            return setting[settingName];
        }
    }
}
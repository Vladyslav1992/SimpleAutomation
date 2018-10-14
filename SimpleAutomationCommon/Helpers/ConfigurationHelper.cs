﻿using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using SimpleAutomationCommon.Helpers.Extensions;

namespace SimpleAutomationCommon.Helpers
{
    public static class ConfigurationHelper
    {
        //public static string TestEnvironment { get; } = "IntegrationTest";
        
        private static string GetSettings(string sectionName, string settingName)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                //.AddJsonFile($"appsettings.{TestEnvironment}.json", optional: true, reloadOnChange: false)
                .AddEnvironmentVariables()
                .Build();

            var setting = configuration.GetSection(sectionName);
            if (setting == null)
                throw new Exception($"{settingName} setting is missing");
            return setting[settingName];
        }

        public static string MainUrl => Environment.GetEnvironmentVariable("simplCommerceEndpoint") ?? GetSettings("App", "homeUrl");
        public static Browser Browser => Browsers.GetBrowser(GetSettings("Browser", "Name"));
        public static TimeSpan RetryTimeOut => TimeSpan.FromMilliseconds(GetSettings("Browser", "retryTimeout").ToInt());
        public static TimeSpan ElementTimeOut => TimeSpan.FromSeconds(GetSettings("Browser", "elementTimeout").Split(':').Last().ToInt());
    }
}
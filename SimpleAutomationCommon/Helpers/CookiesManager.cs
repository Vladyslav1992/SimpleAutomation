﻿namespace SimpleAutomationCommon.Helpers
{
    using System.Collections.ObjectModel;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using DataModels.Builders;
    using DataModels.Enums;
    using DataModels.Users;

    public static class CookiesManager
    {
        public static ReadOnlyCollection<Cookie> GetCookies(string userEmail)
        {
            User user = BaseUsers.GetUser(userEmail);
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            var driver = new ChromeDriver(chromeOptions);
            driver.Navigate().GoToUrl(ConfigurationHelper.MainUrl + SitePages.Login);
            driver.FindElementById("Email").SendKeys(user.Email.Value);
            driver.FindElementByName("Password").SendKeys(user.Password);
            driver.FindElementByXPath("//button[.='Log in']").Click();
            ReadOnlyCollection<Cookie> driverCookies = driver.Manage().Cookies.AllCookies;
            return driverCookies;
        }
    }
}

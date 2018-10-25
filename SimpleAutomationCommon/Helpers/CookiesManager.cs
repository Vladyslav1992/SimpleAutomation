namespace SimpleAutomationCommon.Helpers
{
    using System.Collections.ObjectModel;
    using DataModels.Builders;
    using DataModels.Enums;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    public static class CookiesManager
    {
        public static ReadOnlyCollection<Cookie> GetCookies(string userEmail)
        {
            var user = BaseUsers.GetUser(userEmail);
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            var driver = new ChromeDriver(chromeOptions);
            driver.Navigate().GoToUrl(ConfigurationHelper.MainUrl + SitePages.Login);
            driver.FindElementById("Email").SendKeys(user.Email.Value);
            driver.FindElementByName("Password").SendKeys(user.Password);
            driver.FindElementByXPath("//button[.='Log in']").Click();
            var driverCookies = driver.Manage().Cookies.AllCookies;
            return driverCookies;
        }
    }
}

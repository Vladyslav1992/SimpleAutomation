using System;

namespace SimpleAutomationCommon.Helpers
{
    public static class Browsers
    {
        public static Browser GetBrowser(string setting)
        {
            switch (setting.ToLower())
            {
                case "chrome": return Browser.Chrome;
                case "ie": return Browser.Ie;
                case "firefox": return Browser.Firefox;
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }

    public enum Browser
    {
        Chrome,
        Ie,
        Firefox
    }
}
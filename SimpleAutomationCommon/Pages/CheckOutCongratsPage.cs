﻿namespace SimpleAutomationCommon.Pages
{
    using Atata;
    using OpenQA.Selenium;
    using _ = CheckOutCongratsPage;

    public class CheckOutCongratsPage : BasePage<_>
    {
        [FindByCss("h2")]
        private IWebElement SuccessMessage { get; set; }

        public bool IsLoaded() => SuccessMessage.Displayed;

        public string GetResult() => SuccessMessage.Text;
    }
}
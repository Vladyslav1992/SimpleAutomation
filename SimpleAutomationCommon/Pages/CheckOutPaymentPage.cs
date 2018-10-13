using OpenQA.Selenium;

namespace SimpleAutomationCommon.Pages
{
    public class CheckOutPaymentPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-order']")]
        private IWebElement _cash;

        public bool IsLoaded() => _cash.Displayed;

        public void CashOnDelivery() => _cash.Click();
    }
}

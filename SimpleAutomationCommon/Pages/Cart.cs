using OpenQA.Selenium;

namespace SimpleAutomationCommon.Pages
{
    public class Cart : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = "a[href='/checkout/shipping']")]
        private IWebElement _checkOut;

        [FindsBy(How = How.XPath, Using = "//a[@href='/'][text()='Go to shopping']")]
        private IWebElement _noItems;

        public bool IsLoaded()
        {
            if (_checkOut.IsPresent() || _noItems.IsPresent())
                return true;
            return false;
        }
            

        public void ProcessToCheckout() => _checkOut.Click();

        public bool CheckEmptyCart() => _noItems.Displayed;
    }
}

using System.Threading;
using OpenQA.Selenium;

namespace SimpleAutomationCommon.Pages
{
    public class PhonePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='product-variation ']//button[@class='btn btn-lg btn-add-cart']")]
        private IWebElement _cartButton;

        [FindsBy(How = How.XPath, Using = "//a[text()='View cart']")]
        private IWebElement _viewCart;

        public bool PageIsLoaded() => _cartButton.Displayed;

        public bool PopUpIsLoaded()
        {
            if (!_viewCart.Displayed)
                Thread.Sleep(1000);
            return _viewCart.Displayed;
        } 

        public void AddToCart() => _cartButton.Click();

        public void ViewCart() => _viewCart.Click();
    }
}

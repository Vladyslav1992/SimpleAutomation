namespace SimpleAutomationCommon.Pages
{
    using Atata;
    using _ = Cart;

    public class Cart : BasePage<_>
    {
        [FindByCss("a[href='/checkout/shipping']")]
        private Label<_> CheckOut { get; set; }

        [FindByXPath("//a[@href='/'][text()='Go to shopping']")]
        private Label<_> NoItems { get; set; }

        public bool IsLoaded() => CheckOut.IsVisible || NoItems.IsVisible;

        public void ProcessToCheckout() => CheckOut.Click();

        public bool CheckEmptyCart() => NoItems.IsVisible;
    }
}
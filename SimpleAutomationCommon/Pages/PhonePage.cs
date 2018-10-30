namespace SimpleAutomationCommon.Pages
{
    using Atata;
    using _ = PhonePage;

    public class PhonePage : BasePage<_>
    {
        [FindByXPath("//div[@class='product-variation ']//button[@class='btn btn-lg btn-add-cart']")]
        private Button<_> CartButton { get; set; }

        [FindByXPath("//a[text()='View cart']")]
        private Link<_> ViewCart { get; set; }

        public bool PageIsLoaded() => CartButton.IsVisible;

        public bool PopUpIsLoaded() => ViewCart.IsVisible;

        public void AddToCart() => CartButton.Click();

        public void OpenCart() => ViewCart.Click();
    }
}
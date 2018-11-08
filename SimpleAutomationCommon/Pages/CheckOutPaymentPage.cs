using Atata;

namespace SimpleAutomationCommon.Pages
{
    using _ = CheckOutPaymentPage;

    public class CheckOutPaymentPage : BasePage<_>
    {
        [FindByXPath("//button[@class='btn btn-order']")]
        private Button<_> Cash { get; set; }

        public bool IsLoaded() => Cash.IsVisible;

        public void CashOnDelivery() => Cash.Click();
    }
}

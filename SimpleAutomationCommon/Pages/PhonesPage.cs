namespace SimpleAutomationCommon.Pages
{
    using System.Linq;
    using Atata;
    using _ = PhonesPage;

    public class PhonesPage : BasePage<_>
    {
        [FindByCss("h2")]
        private Label<_> PhonesTitle { get; set; }

        [FindByCss("div[class = 'row product-list'] h5")]
        private OrderedList<ProductItem, _> ProductList { get; set; }

        public class ProductItem : ListItem<_>
        {
            [FindByIndex(0)]
            private Text<_> Name { get; set; }

            [FindByIndex(1)]
            private Number<_> Amount { get; set; }

            public string GetName() => Name.Get();

            public int GetAmount() => (int) Amount.Get().GetValueOrDefault();
        }

        public void ChooseProduct(string productName)
        {
            ProductList.Items.First(p => p.GetName() == productName)?.Click();
        }

        public bool IsLoaded()
            => PhonesTitle.IsVisible;
    }
}
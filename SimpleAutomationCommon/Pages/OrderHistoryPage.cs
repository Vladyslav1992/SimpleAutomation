using System.Linq;
using Atata;

namespace SimpleAutomationCommon.Pages
{
    using _ = OrderHistoryPage;

    public class OrderHistoryPage : BasePage<_>
    {
        [FindByXPath("//tr//p")]
        private OrderedList<OrderItem,_> _orderList { get; set; }

        [FindByCss("h2")] 
        private Label<_> _orderHistory { get; set; }
        
        private class OrderItem : ListItem<_>
        {
            [FindByIndex(0)]
            private Text<_> Name { get; set; }

            public string GetName() => Name.Get();
        }
        
        public string GetOrderProduct(int index) 
            => _orderList.Items.ElementAtOrDefault(index)?.GetName();

        public bool IsLoaded() => _orderHistory.IsVisible;
    }
}
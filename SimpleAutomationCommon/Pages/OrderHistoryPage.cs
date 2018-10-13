using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace SimpleAutomationCommon.Pages
{
    public class OrderHistoryPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//tr//p")]
        private IList<IWebElement> _orderList;

        [FindsBy(How = How.TagName, Using = "h2")]
        private IWebElement _orderHistory;

        public string GetOrderProduct() => _orderList.First().Text;

        public bool IsLoaded() => _orderHistory.Displayed;
    }
}

using System.Collections.Generic;
using System.Linq;
using Atata;

namespace SimpleAutomationCommon.Pages
{
    using _ = PhonesPage;
    public class PhonesPage : BasePage<_>
    {
        [FindsBy(How = How.CssSelector, Using = "div[class = 'row product-list'] h5")]
        private IList<IWebElement> _productList;

        [FindByCss("h2")]
        private Label<_> _phonesTitle;

        public void ChooseProduct(string productName)
        {
            _productList.First(p => p.Text == productName)?.Click();
        }

        public bool IsLoaded() 
            => _phonesTitle.Displayed;

    }
}

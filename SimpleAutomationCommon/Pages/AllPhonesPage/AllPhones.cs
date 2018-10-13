using Atata;

namespace SimpleAutomationCommon.Pages.AllPhonesPage
{
    using _ = AllPhones;
    
    public class AllPhones : Page<_>
    {
        [FindById(TermMatch.Equals, "CurrentSearchOption_Sort")]
        private Select<_> SortingDropdown { get; set; }

        [FindByXPath("//a[@href='#collapse-brand']")]
        private Label<_> BrandFilterExpander { get; set; }
        
        [FindByCss("div#collapse-brand li:nth-of-type(1)")]
        private CheckBox<_> BrandFilerCheckbox { get; set; }
        
        [FindByXPath("//a[@href='#collapse-price']")]
        private Label<_> PriceBrandExpander { get; set; }
        
        [FindByXPath("//div[@class='noUi-origin noUi-connect']")]
        private Label<_> LeftPriceSlider { get; set; }
        
        [FindByXPath("//div[@class='noUi-origin noUi-background']")]
        private Label<_> RightPriceSlider { get; set; }        
        
        [FindByXPath("//a[@href='/samsung-galaxy-a5']")]
        private Label<_> ProductItem { get; set; }
        
        public void OpenSortingDropdown() 
        {
            SortingDropdown.Click();
        }

        public void CollapseBrandFilter()
        {
            BrandFilterExpander.Click();
        }

        public void SelectBrandFilterCheckbox()
        {
            BrandFilerCheckbox.Click();
        }

        public void GoToProductPage()
        {
            ProductItem.Click();
        }
    }
}
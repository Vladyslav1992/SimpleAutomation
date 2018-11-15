namespace SimpleAutomationCommon.Pages
{
    using Atata;
    using _ = ProductPage;

    public class ProductPage : Page<_>
    {
        [FindById("CurrentSearchOption_Sort")]
        [SelectByValue(TermMatch.Contains)]
        private Select<SortByValueOptions, _> SortByFilter { get; set; }

        public void SortAsc()
            => SortByFilter.Set(SortByValueOptions.asc);

        public void SortDesc()
            => SortByFilter.Set(SortByValueOptions.desc);

        public bool IsLoaded()
            => SortByFilter.IsEnabled;
    }

    public enum SortByValueOptions
    {
        [Term("Price: Low to High")] 
        asc,
        desc,
    }
}
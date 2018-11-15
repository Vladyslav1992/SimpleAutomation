using Atata;

namespace SimpleAutomationCommon.Pages
{
    using _ = AboutUsPage;

    [Url("about-us")]
    public class AboutUsPage : BasePage<_>
    {
        [FindByCss("h1")]
        private Label<_> AboutUsTitle { get; }

        public string GetTitle()
        {
            return AboutUsTitle.Get();
        }
    }
}

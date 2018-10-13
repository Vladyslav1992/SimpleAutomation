using OpenQA.Selenium;

namespace SimpleAutomationCommon.Pages
{
    public class CheckOutCongratsPage :BasePage
    {
        [FindsBy(How = How.TagName, Using = "h2")]
        private IWebElement _successMessage;

        public bool IsLoaded() => _successMessage.Displayed;

        public string GetResult() => _successMessage.Text;
    }
}

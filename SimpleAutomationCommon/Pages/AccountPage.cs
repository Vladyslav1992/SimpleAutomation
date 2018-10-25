namespace SimpleAutomationCommon.Pages
{
    using System.Collections.Generic;
    using System.Linq;
    using Atata;
    using Helpers.Extensions;
    using _ = AccountPage;

    public class AccountPage : Page<_>
    {
        [FindByXPath("//a[text()='Edit']")]
        private Label<_> EditAccount { get; set; }

        [FindByXPath("//div[.='Account Information']/following-sibling::div")]
        private Label<_> UserInfo { get; set; }

        public IEnumerable<string> GetInfo()
            => UserInfo.Get().Remove("\r\nEdit", "\r").Split('\n').Select(i => i.Trim());

        public bool IsLoaded()
            => EditAccount.IsEnabled;
    }
}
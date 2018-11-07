using SimpleAutomationCommon.DataModels;
using SimpleAutomationCommon.DataModels.Users;

namespace SimpleAutomationCommon.Pages
{
    using System.Collections.Generic;
    using System.Linq;
    using Atata;
    using Helpers.Extensions;
    using _ = AccountPage;

    [Url("user")]
    public class AccountPage : Page<_>
    {
        [FindByXPath("//a[text()='Edit']")]
        private Text<_> EditAccount { get; set; }

        [FindByXPath("//div[.='Account Information']/following-sibling::div")]
        private Text<_> UserInfo { get; set; }

        public IEnumerable<string> GetInfo()
            => UserInfo.Get().Remove("\r\nEdit", "\r").Split('\n').Select(i => i.Trim());

        public User GetUser()
            => new User { Email = new Email(GetInfo().Last()), FullName = GetInfo().First() };

        public bool IsLoaded()
            => EditAccount.IsEnabled;
    }
}
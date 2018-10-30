﻿using System.Collections.Generic;
using System.Linq;
using Atata;
using SimpleAutomationCommon.Helpers.Extensions;

namespace SimpleAutomationCommon.Pages
{
    using _ = AccountPage;

    [Url("user")]
    public class AccountPage : Page<_>
    {
        [FindByXPath("//a[text()='Edit']")] 
        private Label<_> EditAccount { get; set; }

        [FindByXPath("//div[.='Account Information']/following-sibling::div")] ////div[.='Account Information']/following-sibling::div)/descendant-or-self::label
        private Text<_> UserInfo { get; set; }

        public IEnumerable<string> GetInfo()
            => UserInfo.Get().Remove("\r\nEdit", "\r").Split('\n').Select(i => i.Trim());

        public bool IsLoaded()
            => EditAccount.IsEnabled;
    }
}
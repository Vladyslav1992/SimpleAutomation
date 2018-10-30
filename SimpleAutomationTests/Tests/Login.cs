using Atata;
using NUnit.Framework;
using SimpleAutomationCommon.DataModels.Builders;
using SimpleAutomationCommon.Pages;
using SimpleAutomationCommon.Pages.LoginPg;

namespace SimpleAutomationTests.Tests
{
    public class Login : BaseTest
    {
        [Test]
        public void Test()
        {
            var loginPage = Go.To<LoginPage>();
            loginPage.FillAndSubmit(BaseUsers.GetUser("commonUser"));
            var accountPage = Go.To<AccountPage>();
            accountPage.GetInfo();
        }


    }
    
}

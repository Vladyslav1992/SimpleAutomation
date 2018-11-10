namespace SimpleAutomationTests.Tests
{
    using System.Linq;
    using Atata;
    using FluentAssertions;
    using NUnit.Framework;
    using SimpleAutomationCommon.DataModels.Users;
    using SimpleAutomationCommon.Pages;
    using SimpleAutomationCommon.Pages.LoginPg;
    using TestDataProviders;

    public class LoginTests : BaseTest
    {
        [Test]
        [TestCaseSource(typeof(LoginTestsDataProvider), nameof(LoginTestsDataProvider.ValidTestCases))]
        public void LoginTest(User user)
        {
            var loginPage = Go.To<LoginPage>().FillAndSubmit(user).GetUser().Should().Be(user.FullName);
            var userInfo = Go.To<AccountPage>().GetInfo();
            userInfo.First().Should().Be(user.FullName, $"Because fullName should be {user.FullName}");
            userInfo.Last().Should().Be(user.Email.Value, $"Because Email should be {user.Email.Value}");
        }

        [Test, TestCaseSource(typeof(LoginTestsDataProvider), nameof(LoginTestsDataProvider.InvalidTestCases))]
        public void InvalidLoginTests(string login, string password, string errorMessage)
        {
            var loginPage = Go.To<LoginPage>();
            loginPage.FillAndSubmit(login, password);
            var error = loginPage.GetError();
            error.Should().Be(errorMessage);
        }
    }
}

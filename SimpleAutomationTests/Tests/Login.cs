using System.Linq;
using Atata;
using FluentAssertions;
using NUnit.Framework;
using SimpleAutomationCommon.DataModels.Builders;
using SimpleAutomationCommon.DataModels.Users;
using SimpleAutomationCommon.Pages;
using SimpleAutomationCommon.Pages.LoginPg;
using SimpleAutomationTests.TestDataProviders;

namespace SimpleAutomationTests.Tests
{
    public class Login : BaseTest
    {
        [Test, TestCaseSource(typeof(LoginTestsDataProvider), "ValidTestCases")]
        public void LoginTest(User user)
        {
            var loginPage = Go.To<LoginPage>();
            loginPage.FillAndSubmit(user);
            var userName = loginPage.GetUser();
            userName.Should().Be(user.FullName);
            var accountPage = Go.To<AccountPage>();
            var userInfo = accountPage.GetInfo();
            userInfo.First().Should().Be(user.FullName, $"Because fullName should be {user.FullName}");
            userInfo.Last().Should().Be(user.Email.Value, $"Because Email should be {user.Email.Value}");
        }

        [Test, TestCaseSource(typeof(LoginTestsDataProvider), "InvalidTestCases")]
        public void InvalidLoginTests(string login, string password, string errorMessage)
        {
            var loginPage = Go.To<LoginPage>();
            loginPage.FillAndSubmit(login, password);
            var error = loginPage.GetError();
            error.Should().Be(errorMessage);
        }
    }
}

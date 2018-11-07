using SimpleAutomationCommon.DataModels;
using SimpleAutomationCommon.Pages;

namespace SimpleAutomationTests.Tests.RegistrationTests
{
    using System.Linq;
    using Atata;
    using FluentAssertions;
    using NUnit.Framework;
    using SimpleAutomationCommon.DataModels.Users;
    using SimpleAutomationCommon.Pages.RegistrationPg;
    using SimpleAutomationTests.TestDataProviders;

    public class RegistrationTests : BaseTest
    {
        [Test]
        public void RegisterWithValidData()
        {
            var email = Randomizer.GetString() + "@test.com";
            var expectedUser = new User { Email = new Email(email), FullName = "validUser", Password = "qwerty" };

            var regitrationPage = Go.To<RegistrationPage>();

            regitrationPage.FillAndSubmit(expectedUser);
            regitrationPage.IsRegistered().Should().Be(true);

            Go.To<AccountPage>()
            .GetUser()
            .Should()
            .BeEquivalentTo(expectedUser, options => options.Excluding(u => u.Password));
        }

        [Test, TestCaseSource(typeof(RegistrationTestsDataProvider), "InvalidTestData")]
        public void RegisterWithInvalidData(string email, string fullName, string password, string cpassword, string errorMessage)
        {
            var regitrationPage = Go.To<RegistrationPage>();

            regitrationPage.FillAndSubmit(email, fullName, password, cpassword);
            regitrationPage
            .GetErrors()
            .Should()
            .Contain(errorMessage);
        }
    }
}

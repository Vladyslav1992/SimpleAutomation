using Atata;
using FluentAssertions;
using NUnit.Framework;
using SimpleAutomationCommon.DataModels;
using SimpleAutomationCommon.DataModels.Users;
using SimpleAutomationCommon.Pages;
using SimpleAutomationCommon.Pages.RegistrationPg;
using SimpleAutomationTests.TestDataProviders;

namespace SimpleAutomationTests.Tests.RegistrationTests
{
    public class RegistrationTests : BaseTest
    {
        [Test]
        public void RegisterWithValidData()
        {
            var email = Randomizer.GetString() + "@test.com";
            var expectedUser = new User { Email = new Email(email), FullName = "validUser", Password = "qwerty" };

            Go.To<RegistrationPage>()
                .FillAndSubmit(expectedUser)
                .IsRegistered().Should().Be(true);

            Go.To<AccountPage>()
                .GetUser()
                .Should()
                .BeEquivalentTo(expectedUser, options => options.Excluding(u => u.Password));
        }

        [Test, TestCaseSource(typeof(RegistrationTestsDataProvider), "InvalidTestData")]
        public void RegisterWithInvalidData(string email, string fullName, string password, string cpassword,
            string errorMessage)
        {
            Go.To<RegistrationPage>()
                .FillAndSubmit(email, fullName, password, cpassword)
                .GetErrors()
                .Should()
                .Contain(errorMessage);
        }
    }
}
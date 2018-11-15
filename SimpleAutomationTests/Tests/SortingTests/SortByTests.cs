namespace SimpleAutomationTests.Tests.SortingTests
{
    using Atata;
    using FluentAssertions;
    using NUnit.Framework;
    using SimpleAutomationCommon.DataModels;
    using SimpleAutomationCommon.DataModels.Users;
    using SimpleAutomationCommon.Pages;
    using SimpleAutomationCommon.Pages.RegistrationPg;
    
    public class SortByTests : BaseTest
    {
        [Test]
        public void LowToHigh()
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
        
        [Test]
        public void HighToLow()
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

    }
}
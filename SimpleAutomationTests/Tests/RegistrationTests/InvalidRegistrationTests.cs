using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atata;
using NUnit.Framework;
using SimpleAutomationCommon.Pages.RegistrationPg;
using FluentAssertions;

namespace SimpleAutomationTests.Tests.RegistrationTests
{
    public class InvalidRegistrationTests : BaseTest
    {
        [Test]
        public void RegistrationWithoutEmail()
        {
            var regitrationPage = Go.To<RegistrationPage>();
            regitrationPage.FillAndSubmit(string.Empty, "invalidUser", "qwerty", "qwerty");

            regitrationPage.GetErrors().Should().Contain("The Email field is required.");
        }
    }
}

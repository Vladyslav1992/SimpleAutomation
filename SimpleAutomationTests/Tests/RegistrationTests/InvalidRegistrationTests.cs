using System;
using System.Collections.Generic;
using System.Text;
using Atata;
using NUnit.Framework;
using SimpleAutomationCommon.Pages.RegistrationPg;

namespace SimpleAutomationTests.Tests.RegistrationTests
{
    public class InvalidRegistrationTests : BaseTest
    {
        [Test]
        public void RegistrationWithoutEmail()
        {
            var regitrationPage = Go.To<RegistrationPage>();
            regitrationPage.FillAndSubmit(string.Empty, "invalidUser", "qwerty", "qwerty");

            regitrationPage.EmailError.Should.Equals("The Email field is required.");
        }
    }
}

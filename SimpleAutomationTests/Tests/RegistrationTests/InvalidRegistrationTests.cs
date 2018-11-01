﻿using System;
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
        public void RegisterWithoutEmail()
        {
            var regitrationPage = Go.To<RegistrationPage>();
            regitrationPage.FillAndSubmit(string.Empty, "invalidUser", "qwerty", "qwerty");

            regitrationPage.GetErrors().Should().Contain("The Email field is required.");
        }

        [Test]
        public void RegisterWithoutFullName()
        {
            var regitrationPage = Go.To<RegistrationPage>();
            regitrationPage.FillAndSubmit("invalidUser@test.com", string.Empty, "qwerty", "qwerty");

            regitrationPage.GetErrors().Should().Contain("The Name field is required.");
        }

        [Test]
        public void RegisterWithoutPassword()
        {
            var regitrationPage = Go.To<RegistrationPage>();
            regitrationPage.FillAndSubmit("invalidUser@test.com", "invalidUser", string.Empty, "qwerty");

            regitrationPage.GetErrors().Should().Contain("The Password field is required.");
        }

        [Test]
        public void RegisterWithoutCPassword()
        {
            var regitrationPage = Go.To<RegistrationPage>();
            regitrationPage.FillAndSubmit("invalidUser@test.com", "invalidUser", "qwerty", string.Empty);

            regitrationPage.GetErrors().Should().Contain("The password and confirmation password do not match.");
        }

        [Test]
        public void RegisterWithIncorrectEmail()
        {
            var regitrationPage = Go.To<RegistrationPage>();
            regitrationPage.FillAndSubmit("invalidUser", "invalidUser", "qwerty", "qwerty");

            regitrationPage.GetErrors().Should().Contain("The Email field is not a valid e-mail address.");
        }

        [Test]
        public void RegisterWithShortPassword()
        {
            var regitrationPage = Go.To<RegistrationPage>();
            regitrationPage.FillAndSubmit("invalidUser@test.com", "invalidUser", "qwerty", "qwerty");

            regitrationPage.GetErrors().Should().Contain("The Password must be at least 4 and at max 100 characters long.");
        }

        [Test]
        public void RegisterWithLongPassword()
        {
            var regitrationPage = Go.To<RegistrationPage>();
            regitrationPage.FillAndSubmit("invalidUser@test.com", "invalidUser", "qwerty", "qwerty");

            regitrationPage.GetErrors().Should().Contain("The Password must be at least 4 and at max 100 characters long.");
        }
    }
}

﻿using Atata;
using NUnit.Framework;
using SimpleAutomationCommon.Pages.LoginPg;

namespace SimpleAutomationTests.Tests
{
    public class TestsTest : BaseTest
    {
        [Test]
        public void Test()
        {
            var loginPage = Go.To<LoginPage>();
            loginPage.FillForm("zlo", "zlo");
        }
    }
}

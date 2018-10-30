namespace SimpleAutomationTests.Tests
{
    using Atata;
    using NUnit.Framework;
    using SimpleAutomationCommon.Pages.LoginPg;

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

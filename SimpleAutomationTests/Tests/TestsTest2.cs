namespace SimpleAutomationTests.Tests
{
    using Atata;
    using NUnit.Framework;
    using SimpleAutomationCommon.Pages.LoginPg;

    public class TestsTest2 : BaseTest
    {
        [Test]
        public void Test2()
        {
            var loginPage = Go.To<LoginPage>();
            loginPage.FillForm("zlo", "zlo");
        }
    }
}

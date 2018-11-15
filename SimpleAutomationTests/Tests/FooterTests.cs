using Atata;
using FluentAssertions;
using NUnit.Framework;
using SimpleAutomationCommon.Pages;
using SimpleAutomationCommon.Pages.LoginPg;

namespace SimpleAutomationTests.Tests
{
    public class FooterTests : BaseTest
    {
        [Test]
        public void AboutUsTest()
        {
            var aboutUsPage = Go.To<LoginPage>().AboutUs.ClickAndGo();
            var title = aboutUsPage.GetTitle();
            title.Should().Be("About Us");
        }
    }
}

using Atata;
using NUnit.Framework;

namespace SimpleAutomationCommon
{
    [TestFixture]
    public class UiTestFixture
    {
        [SetUp]
        public void SetUp()
        {
            // Find information about AtataContext set-up on https://atata-framework.github.io/getting-started/#set-up.
            AtataContext.Configure().
                //UseChrome().
                //    WithArguments("start-maximized").
                //    WithFixOfCommandExecutionDelay().
                //    WithLocalDriverPath().
                //UseBaseUrl("SITE_URL").
                UseCulture("en-us").
                UseNUnitTestName().
                AddNUnitTestContextLogging().
                LogNUnitError().
                Build();
        }

        [TearDown]
        public void TearDown()
        {
            AtataContext.Current?.CleanUp();
        }
    }
}

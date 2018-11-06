using System.Collections;
using NUnit.Framework;
using SimpleAutomationCommon.DataModels.Builders;
using SimpleAutomationCommon.DataModels.Users;

namespace SimpleAutomationTests.TestDataProviders
{
    public class LoginTestsDataProvider
    {
        public static IEnumerable InvalidTestCases
        {
            get
            {
                yield return new TestCaseData("nonExistingUser@loketa.com", "qwerty", "Invalid login attempt.");
                yield return new TestCaseData("nonExistingUser", "qwerty", "The Email field is not a valid e-mail address.");
                yield return new TestCaseData("testuser@oranek.com", "qwerty1", "Invalid login attempt.");
                yield return new TestCaseData(string.Empty, "qwerty", "The Email field is required.");
                yield return new TestCaseData("admin@simplcommerce.com", string.Empty, "The Password field is required.");
            }
        }

        public static IEnumerable ValidTestCases
        {
            get
            {
                yield return new TestCaseData(BaseUsers.GetUser("commonUser"));
                yield return new TestCaseData(BaseUsers.GetUser("admin"));
            }
        }
    }
}

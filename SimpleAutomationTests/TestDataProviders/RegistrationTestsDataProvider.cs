namespace SimpleAutomationTests.TestDataProviders
{
    using System.Collections;
    using NUnit.Framework;

    public class RegistrationTestsDataProvider
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(string.Empty, "invalidUser2", "qwerty", "qwerty", "The Email field is required.");
                yield return new TestCaseData(string.Empty, "invalidUser1", "qwerty", "qwerty", "The Email field is required.");
                yield return new TestCaseData(string.Empty, "invalidUser3", "qwerty", "qwerty", "The Email field is required.");
                yield return new TestCaseData(string.Empty, "invalidUser4", "qwerty", "qwerty", "The Email field is required.");
            }
        }
    }
}

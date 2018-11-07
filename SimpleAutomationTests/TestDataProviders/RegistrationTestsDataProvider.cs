namespace SimpleAutomationTests.TestDataProviders
{
    using System.Collections;
    using NUnit.Framework;

    public class RegistrationTestsDataProvider
    {
        public static IEnumerable InvalidTestData
        {
            get
            {
                yield return new TestCaseData(string.Empty, "invalidUser", "qwerty", "qwerty", "The Email field is required.");
                yield return new TestCaseData("invalidUser@test.com", string.Empty, "qwerty", "qwerty", "The Name field is required.");
                yield return new TestCaseData("invalidUser@test.com", "invalidUser", string.Empty, "qwerty", "The password and confirmation password do not match.");
                yield return new TestCaseData("invalidUser@test.com", "invalidUser", "qwerty", string.Empty, "The password and confirmation password do not match.");
                yield return new TestCaseData("invalidUser", "invalidUser", "qwerty", "qwerty", "The Email field is not a valid e-mail address.");
                yield return new TestCaseData("invalidUser@test.com", "invalidUser", "qwe", "qwe", "The Password must be at least 4 and at max 100 characters long.");
                yield return new TestCaseData("invalidUser@test.com", "invalidUser", "dscgfvkjdfvkjhifvyfusgkjfsvkjdfsdscgfvkjdfvkjhifvyfusgkjfsvkjdfsdscgfvkjdfvkjhifvyfusgkjfsvkjdfsdscdE", "dscgfvkjdfvkjhifvyfusgkjfsvkjdfsdscgfvkjdfvkjhifvyfusgkjfsvkjdfsdscgfvkjdfvkjhifvyfusgkjfsvkjdfsdscdE", "The Password must be at least 4 and at max 100 characters long.");
            }
        }
    }
}

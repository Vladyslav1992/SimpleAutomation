namespace SimpleAutomationCommon.DataModels.Builders
{
    using System.Collections.Generic;
    using Users;

    public static class BaseUsers
    {
        private static readonly Dictionary<string, User> Users = new Dictionary<string, User>
        {
            ["commonUser"] = new User { FullName = "commonUser", Password = "qwerty", Email = new Email("testuser@oranek.com") },
            ["admin"] = new User { FullName = "Shop Admin", Password = "1qazZAQ!", Email = new Email("admin@simplcommerce.com") }
        };

        public static User GetUser(string user) => Users[user];
    }
}

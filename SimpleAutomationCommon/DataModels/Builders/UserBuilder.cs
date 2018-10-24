namespace SimpleAutomationCommon.DataModels.Builders
{
    using System.Collections.Generic;
    using SimpleAutomationCommon.DataModels.Users;

    public static class BaseUsers
    {
        private static readonly Dictionary<string, User> Users = new Dictionary<string, User>
        {
            ["generaluser@loketa.com"] = new User { FullName = "commonUser", Password = "P@ssw0rd", Email = new Email("generaluser@loketa.com") },
            ["admin@simplcommerce.com"] = new User { FullName = "Shop Admin", Password = "P@ssw0rd", Email = new Email("admin@simplcommerce.com") }
        };

        public static User GetUser(string user) => Users[user];
    }
}

namespace SimpleAutomationCommon.DataModels.Enums
{
    using System.ComponentModel;

    public enum SitePages
    {
        [Description("phones")]
        Phones,

        [Description("tablets")]
        Tablets,

        [Description("user-groups")]
        UserGroups,

        [Description("computers")]
        Computers,

        [Description("accessories")]
        Accessories,

        [Description("login")]
        Login,

        [Description("user")]
        User,

        [Description("register")]
        Registration,

        [Description("cart")]
        Cart,

        [Description("checkout/shipping")]
        Shipping,

        [Description("checkout/payment")]
        Payment,

        [Description("checkout/congratulation")]
        Congratulation,

        [Description("user/order-history")]
        OrderHistory
    }
}
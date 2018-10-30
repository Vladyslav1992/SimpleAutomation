namespace SimpleAutomationCommon.DataModels
{
    using System.Collections.Generic;
    using Enums;

    public class BaseProduct
    {
        public string Name;

        public int Price;

        public string Detail;

        public Dictionary<ProductAttributes, string> Attributes;
    }
}

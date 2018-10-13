using System.Collections.Generic;
using SimpleAutomationCommon.DataModels.Enums;

namespace SimpleAutomationCommon.DataModels
{
    public class BaseProduct
    {
        public string Name;

        public int Price;

        public string Detail;

        public Dictionary<ProductAttributes, string> Attributes;
    }
}

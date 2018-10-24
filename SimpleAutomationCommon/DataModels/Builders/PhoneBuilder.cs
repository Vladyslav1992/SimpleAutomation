namespace SimpleAutomationCommon.DataModels.Builders
{
    using System.Collections.Generic;
    using SimpleAutomationCommon.DataModels.Enums;

    public class PhoneBuilder
    {
        private readonly Phone _phone;

        public PhoneBuilder()
        {
            _phone = new Phone();
        }

        public Phone Build()
        {
            return _phone;
        }

        public Phone DefaultBuild()
        {
            _phone.Name = "DefaultProductName";
            _phone.Price = 123456;
            _phone.Detail = "Bla-Bla";
            _phone.Attributes = new Dictionary<ProductAttributes, string>
            {
                [ProductAttributes.Os] = "wINDOWS",
            };
            return _phone;
        }

        public PhoneBuilder WithName(string phoneName)
        {
            _phone.Name = phoneName;
            return this;
        }

        public PhoneBuilder WithPrice(int phonePrice)
        {
            _phone.Price = phonePrice;
            return this;
        }

        public PhoneBuilder WithProductDetail(string phoneProductDetail)
        {
            _phone.Detail = phoneProductDetail;
            return this;
        }

        public PhoneBuilder WithAttribute(ProductAttributes key, string value)
        {
            _phone.Attributes.Add(key, value);
            return this;
        }

        public PhoneBuilder WithAttributes(Dictionary<ProductAttributes, string> attributes)
        {
            _phone.Attributes = attributes;
            return this;
        }
    }
}

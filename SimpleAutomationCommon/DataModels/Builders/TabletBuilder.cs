namespace SimpleAutomationCommon.DataModels.Builders
{
    using System.Collections.Generic;
    using Enums;

    public class TabletBuilder
    {
        private readonly Tablet _tablet;

        public TabletBuilder()
        {
            _tablet = new Tablet();
        }

        public TabletBuilder WithName(string name)
        {
            _tablet.Name = name;
            return this;
        }

        public TabletBuilder WithPrice(int price)
        {
            _tablet.Price = price;
            return this;
        }

        public TabletBuilder WithDetails(string details)
        {
            _tablet.Detail = details;
            return this;
        }

        public TabletBuilder WithAttribute(ProductAttributes key, string value)
        {
            _tablet.Attributes.Add(key, value);
            return this;
        }

        public TabletBuilder WithAttributes(Dictionary<ProductAttributes, string> attributes)
        {
            _tablet.Attributes = attributes;
            return this;
        }

        public Tablet Build()
        {
            return _tablet;
        }
    }
}

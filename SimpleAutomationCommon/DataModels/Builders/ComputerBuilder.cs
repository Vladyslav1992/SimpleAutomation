namespace SimpleAutomationCommon.DataModels.Builders
{
    using System.Collections.Generic;
    using Enums;

    public class ComputerBuilder
    {
        private readonly Computer _computer;

        public ComputerBuilder()
            => _computer = new Computer();

        public ComputerBuilder WithName(string name)
        {
            _computer.Name = name;
            return this;
        }

        public ComputerBuilder WithPrice(int price)
        {
            _computer.Price = price;
            return this;
        }

        public ComputerBuilder WithDetail(string detail)
        {
            _computer.Detail = detail;
            return this;
        }

        public ComputerBuilder WithAttribute(ProductAttributes key, string value)
        {
            _computer.Attributes.Add(key, value);
            return this;
        }

        public ComputerBuilder WithAttributes(Dictionary<ProductAttributes, string> attributes)
        {
            _computer.Attributes = attributes;
            return this;
        }

        public Computer Build()
        {
            return _computer;
        }
    }
}

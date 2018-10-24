namespace SimpleAutomationCommon.Helpers.Extensions
{
    using System;
    using System.ComponentModel;

    public static class EnumExtensions
    {
        public static string GetEnumDescription(this Enum enumValue)
        {
            var enumValueAsString = enumValue.ToString();

            var type = enumValue.GetType();
            var fieldInfo = type.GetField(enumValueAsString);
            var attributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length <= 0) return enumValueAsString;
            var attribute = (DescriptionAttribute) attributes[0];
            return attribute.Description;
        }
        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException($"Not found {description}");
        }
    }
}
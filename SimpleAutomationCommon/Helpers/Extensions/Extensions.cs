namespace SimpleAutomationCommon.Helpers.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class Extensions
    {
        public static List<T> ParseToList<T>(this string comaSeparatesString)
        {
            var stringArray = !comaSeparatesString.IsNullOrEmpty()
                ? comaSeparatesString.Split(new[] { "," }, StringSplitOptions.None).Select(x => x.Trim())
                : null;

            return stringArray?.ToList().ConvertList<T>() ?? new List<T>();
        }

        public static List<T> ConvertList<T>(this IEnumerable<string> list)
        {
            var type = typeof(T);
            var converter = TypeDescriptor.GetConverter(type);
            return list.Select(x => (T)converter.ConvertFrom(x)).ToList();
        }

        public static DateTime? ParseBddDate(this string date)
        {
            if (date == null)
            {
                return null;
            }

            var match = new Regex(@"\(Today\s*((?<sign>[+-])\s*(?<days>\d+)\))*").Match(date);
            if (!match.Success)
            {
                if (DateTime.TryParse(date, out var dateTime))
                {
                    return dateTime.ToUniversalTime();
                }

                return null;
            }

            var result = DateTime.UtcNow.Date;
            if (match.Groups["sign"].Success && match.Groups["days"].Success)
            {
                var dayOperator = match.Groups["sign"].Value;
                var dayNumber = match.Groups["days"].Value;
                result = result.AddDays(Convert.ToInt32(dayOperator + dayNumber));
            }
            return result.Date;
        }

        private static bool IsNullableType(this Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        private static Type GetTypeOfNullable(this Type type)
        {
            return type.GetGenericArguments()[0];
        }

        public static string RemoveControlCharacters(this string inText)
            => inText
                .Replace("\0", string.Empty)
                .Replace("\a", string.Empty)
                .Replace("\b", string.Empty)
                .Replace("\t", string.Empty)
                .Replace("\f", string.Empty)
                .Replace("\n", string.Empty)
                .Replace("\r", string.Empty);

        public static IEnumerable<T> Add<T>(this IEnumerable<T> enumerable, params T[] items)
        {
            return enumerable.Concat(items);
        }
        
        public static string GetEnumDescription(this Enum enumValue)
        {
            var enumValueAsString = enumValue.ToString();

            var type = enumValue.GetType();
            var fieldInfo = type.GetField(enumValueAsString);
            var attributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length <= 0)
            {
                return enumValueAsString;
            }

            var attribute = (DescriptionAttribute)attributes[0];
            return attribute.Description;
        }
        
        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum)
            {
                throw new InvalidOperationException();
            }

            foreach (var field in type.GetFields())
            {
                if (Attribute.GetCustomAttribute(
                    field,
                    typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                    {
                        return (T)field.GetValue(null);
                    }
                }
                else
                {
                    if (field.Name == description)
                    {
                        return (T)field.GetValue(null);
                    }
                }
            }
            throw new ArgumentException($"Not found {description}");
        }
    }
}

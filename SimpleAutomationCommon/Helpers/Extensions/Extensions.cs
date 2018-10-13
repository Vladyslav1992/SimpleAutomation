using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace SimpleAutomationCommon.Helpers.Extensions
{
    public static class Extensions
    {
        public static T GetValueFromRow<T>(this TableRow tableRow, string columnName, T defaultValue = default(T))
        {
            if (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(IEnumerable<>))
                throw new InvalidOperationException("T can't be IEnumerable<>. Use GetIdsFromFirstRow instead");

            string value;
            if (!tableRow.TryGetValue(columnName, out value) || value.IsNullOrEmpty())
                return defaultValue;

            var type = typeof(T);
            type = type.IsNullableType() ? type.GetTypeOfNullable() : type;

            var converter = TypeDescriptor.GetConverter(type);
            return (T)converter.ConvertFrom(value);
        }

        public static object GetValueFromRow(this TableRow tableRow, string columnName, Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                throw new InvalidOperationException("T can't be IEnumerable<>. Use GetIdsFromFirstRow instead");

            string value;
            if (!tableRow.TryGetValue(columnName, out value) || value.IsNullOrEmpty())
                return Activator.CreateInstance(type);

            type = type.IsNullableType() ? type.GetTypeOfNullable() : type;

            var converter = TypeDescriptor.GetConverter(type);
            return converter.ConvertFrom(value);
        }

        public static List<int> ParseIdsToList(this string companyIds)
        {
            var stringArray = !companyIds.IsNullOrEmpty()
                ? companyIds.Split(new[] { "," }, StringSplitOptions.None)
                : null;

            return stringArray?.Select(int.Parse).ToList() ?? new List<int>();
        }

        public static List<T> ParseToList<T>(this string companyIds)
        {
            var stringArray = !companyIds.IsNullOrEmpty()
                ? companyIds.Split(new[] { "," }, StringSplitOptions.None).Select(x => x.Trim())
                : null;

            return stringArray?.ToList().ConvertList<T>() ?? new List<T>();
        }

        public static List<T> ConvertList<T>(this List<string> list)
        {
            var type = typeof(T);
            var converter = TypeDescriptor.GetConverter(type);
            return list.Select(x => (T)converter.ConvertFrom(x)).ToList();
        }

        public static DateTime? ParseBddDate(this string date)
        {
            if (date == null)
                return null;
            var match = new Regex(@"\(Today\s*((?<sign>[+-])\s*(?<days>\d+)\))*").Match(date);
            if (!match.Success)
            {
                if (DateTime.TryParse(date, out DateTime dateTime))
                    return dateTime.ToUniversalTime();
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

        /// <summary>
        /// Automapper implementation to identify of the type is nullable
        /// </summary>
        private static bool IsNullableType(this Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        /// <summary>
        /// Automapper implementation to get type of nullable
        /// </summary>
        private static Type GetTypeOfNullable(this Type type)
        {
            return type.GetGenericArguments()[0];
        }

        public static string RemoveControlCharacters(this string inText)
            => inText
                .Replace("\0", "")
                .Replace("\a", "")
                .Replace("\b", "")
                .Replace("\t", "")
                .Replace("\f", "")
                .Replace("\n", "")
                .Replace("\r", "");

        public static IEnumerable<T> Add<T>(this IEnumerable<T> enumerable, params T[] items)
        {
            return enumerable.Concat(items);
        }
    }
}

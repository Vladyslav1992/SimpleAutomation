namespace SimpleAutomationCommon.Helpers.Extensions
{
    using System;

    public static class StringExtensions
    {
        public static string RemoveWhiteSpaces(this string @string)
        {
            var parts = @string.Split(' ');
            return string.Join(string.Empty, parts);
        }

        public static string Remove(this string @string, params string[] partsToRemove)
        {
            partsToRemove.ForEach(p => @string = @string.Replace(p, string.Empty));
            return @string;
        }

        public static bool IsNullOrEmpty(this string s)
            => string.IsNullOrEmpty(s);

        public static int ToInt(this string s)
            => int.Parse(s);

        public static decimal? ToDecimal(this string s)
        {
            if (decimal.TryParse(s, out var value))
            {
                return value;
            }

            return null;
        }

        public static DateTime ToDateTime(this string s)
        {
            DateTime.TryParse(s, out var date);
            return date;
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
    }
}
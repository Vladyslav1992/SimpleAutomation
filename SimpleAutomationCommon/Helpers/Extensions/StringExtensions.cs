using System;

namespace SimpleAutomationCommon.Helpers.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveWhiteSpaces(this string @string)
        {
            var parts = @string.Split(' ');
            return string.Join("", parts);
        }

        public static string Remove(this string @string, params string[] partsToRemove)
        {
            partsToRemove.ForEach(p => @string = @string.Replace(p, ""));
            return @string;
        }

        public static bool IsNullOrEmpty(this string s)
            => string.IsNullOrEmpty(s);

        public static int ToInt(this string s)
            => int.Parse(s);

        public static decimal? ToDecimal(this string s)
        {
            if (decimal.TryParse(s, out var value))
                return value;
            return null;
        }

        public static DateTime ToDateTime(this string s)
        {
            DateTime.TryParse(s, out var date);
            return date;
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
    }
}
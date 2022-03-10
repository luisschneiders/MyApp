using System;
namespace BaseLibrary
{
    /*
     * Syntax for declaring extension methods, a new feature of C# 3.0
     */
    public static class StringExtensions
    {
        #nullable enable
        public static string? Truncate(this string? value, int maxLength, string suffix = "...")
        {
            return value?.Length > maxLength ? value.Substring(0, maxLength) + suffix : value;
        }
    }
}

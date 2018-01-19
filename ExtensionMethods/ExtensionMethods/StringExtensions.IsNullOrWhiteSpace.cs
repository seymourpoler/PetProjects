using System;

namespace ExtensionMethods
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string text)
        {
            return String.IsNullOrWhiteSpace(text);
        }
        
        public static bool IsNotNullAndNotWhiteSpace(this string text)
        {
            return !String.IsNullOrWhiteSpace(text);
        }
    }
}
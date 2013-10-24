using System;

namespace Squel
{
    public static class Functions
    {
        public static bool IsStringEmpty(string value)
        {
            return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
        }
    }
}

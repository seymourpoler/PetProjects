using System;
using System.Text;
using System.Collections.Generic;

namespace Squel
{
    public static class Functions
    {
        public static bool IsStringEmpty(string value)
        {
            return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
        }

        public static string GetString(string word, string value)
        {
            if (Functions.IsStringEmpty(value))
            {
                return string.Empty;
            }
            return string.Format("{0}{1}", word, value);
        }

        public static string Map(IList<string> list, string separator)
        {
            var result = new StringBuilder();
            for (var cont = 0; cont < list.Count; cont++)
            {
                result.Append(list[cont]);
                if (cont < list.Count - 1)
                { result.Append(separator); }
            }

            return result.ToString();
        }
    }
}

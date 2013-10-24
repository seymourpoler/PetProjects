using System;
using System.Text;
using System.Collections.Generic;

namespace Squel
{
    public abstract class QueryBase
    {
        protected string GetString(string word, string value)
        {
            if (Functions.IsStringEmpty(value))
            {
                return string.Empty;
            }
            return string.Format("{0}{1}", word, value);
        }

        protected string Map(IList<string> list, string separator)
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

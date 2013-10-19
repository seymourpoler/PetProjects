using System;

namespace Squel
{
    public abstract class QueryBase
    {
        protected bool IsStringEmpty(string value)
        {
            return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
        }

        protected string GetString(string word, string value)
        {
            if (IsStringEmpty(value))
            {
                return string.Empty;
            }
            return string.Format("{0}{1}", word, value);
        }
    }
}

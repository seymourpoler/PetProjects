using System;
using System.Text;
using System.Collections.Generic;

namespace Squel
{
    public partial class SQL
    {
        private const string UPDATE = "UPDATE ";
        private const string SET = "SET ";

        private string _update;
        private string _table;
        private string _set;

        private string GetStringSet()
        {
            return GetString(SET, _set);
        }

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

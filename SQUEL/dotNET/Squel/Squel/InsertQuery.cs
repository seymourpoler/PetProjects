using System;
using System.Collections.Generic;

namespace Squel
{
    public class InsertQuery : QueryBase, IQuery
    {
        private const string INSERT = "INSERT ";
        private const string INTO = "INTO ";
        private const string VALUES = " VALUES ";

        private string _into;
        private IList<string> _fields;
        private IList<string> _values;

        public InsertQuery()
        {
            _into = string.Empty;
            _fields = new List<string>();
            _values = new List<string>();
        }

        public string ToSQLString()
        {
            var fields = GetStringFields();
            var values = GetStringValues();
            return string.Format("{0}{1}{2}{3}{4}{5}", INSERT, INTO, _into, fields, VALUES, values);
        }
         
        public InsertQuery Into(string into)
        {
            _into = string.Format("{0} ", into);
            return this;
        }

        public InsertQuery Set(string field, int value)
        {
            return Set(field, value.ToString());
        }

        public InsertQuery Set(string field, object value)
        {
            if (value == null)
            {
                return Set(field, "NULL");
            }
            return Set(field, value.ToString());
        }

        public InsertQuery Set(string field, double value)
        {
            var stringValue = value.ToString().Replace(',', '.');
            return Set(field, stringValue);
        }

        public InsertQuery Set(string field, string value)
        {
            if (value == null)
            {
                value = "NULL";
            }

            _fields.Add(field);
            _values.Add(value);
            return this;
        }

        private string GetStringFields()
        {
            var fields = Functions.Map(_fields, ", ");
            return string.Format("({0})", fields);
        }

        private string GetStringValues()
        {
            var values = Functions.Map(_values, ", ");
            return string.Format("({0})", values);
        }
    }
}

using System;
using System.Collections.Generic;

namespace Squel
{
    public class UpdateQuery : QueryBase, IQuery
    {
        private const string UPDATE = "UPDATE ";
        private const string SET = "SET ";
        private const string WHERE = " WHERE ";

        private string _table;
        private IList<string> _set;
        private IList<string> _where;

        public UpdateQuery()
        {
            _set = new List<string>();
            _where = new List<string>();
        }

        public string ToSQLString()
        {
            var where = GetStringWhere();
            var set = GetStringSet();
            return string.Format("{0}{1}{2}{3}", UPDATE, _table, set, where);
        }

        public UpdateQuery Table(string table)
        {
            _table = string.Format("{0} ", table);
            return this;
        }

        public UpdateQuery Set(string field, int value)
        {
            if (value == null)
            {
                return Set(field, "NULL");
            }
            return Set(field, value.ToString());
        }

        public UpdateQuery Set(string field, object value)
        {
            if (value == null)
            {
                return Set(field, "NULL");
            }
            return Set(field, value.ToString());
        }

        public UpdateQuery Set(string field, double value)
        {
            var stringValue = value.ToString().Replace(',', '.');
            return Set(field, stringValue);
        }
        
        public UpdateQuery Set(string field, string value)
        {
            if (value == null)
            {
                value = "NULL";
            }
            var set = string.Format("{0} = {1}", field, value);
            _set.Add(set);
            return this;
        }

        public UpdateQuery Where(string where)
        {
            var expression = string.Format("({0})", where);
            _where.Add(expression);
            return this;
        }

        private string GetStringWhere()
        {
            var where = Functions.Map(_where, " AND ");
            return Functions.GetString(WHERE, where);
        }

        private string GetStringSet()
        {
            var set = Functions.Map(_set, ", ");
            return Functions.GetString(SET, set);
        }
    }
}

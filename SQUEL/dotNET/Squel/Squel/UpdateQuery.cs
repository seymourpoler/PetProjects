using System;

namespace Squel
{
    public class UpdateQuery : QueryBase, IQuery
    {

        private const string UPDATE = "UPDATE ";
        private const string SET = "SET ";
        private const string WHERE = " WHERE ";

        private string _table;
        private string _set;
        private string _where;

        public UpdateQuery()
        { 
        }

        public string ToSQLString()
        {
            var where = GetStringWhere();
            return string.Format("{0}{1}{2}{3}{4}", UPDATE, _table, SET, _set, where);
        }

        public UpdateQuery Table(string table)
        {
            _table = string.Format("{0} ", table);
            return this;
        }

        public UpdateQuery Set(string field, string value)
        {
            _set = string.Format("{0} = {1}", field, value);
            return this;
        }

        public UpdateQuery Where(string where)
        {
            _where = where;
            return this;
        }

        private string GetStringWhere()
        {
            return GetString(WHERE, _where);
        }
    }
}

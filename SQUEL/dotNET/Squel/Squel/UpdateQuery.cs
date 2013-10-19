using System;
using System.Collections.Generic;

namespace Squel
{
    public class UpdateQuery : QueryBase, IQuery
    {

        private const string UPDATE = "UPDATE ";
        private const string SET = "SET ";

        private string _update;
        private string _table;
        private string _set;

        public UpdateQuery()
        { 
        }

        public string ToSQLString()
        {
            return string.Format("{0}{1}{2}{3}", UPDATE, _table, SET, _set);
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
    }
}

using System;
using System.Collections.Generic;

namespace Squel
{
    public partial class SQL
    {
        private IQuery query;

        public SQL()
        {
        }

        public override string ToString()
        {
            return query.ToSQLString();
        }

        public SelectQuery Select(string field)
        {
            query = new SelectQuery(field);
            return (SelectQuery)query;
        }

        public SelectQuery Select()
        {
            query = new SelectQuery();
            return (SelectQuery)query;
        }

        public SQL Update()
        {
            _update = UPDATE;
            return this;
        }

        public SQL Table(string table)
        {
            _table = string.Format("{0} ", table);
            return this;
        }

        public SQL Set(string field, string value)
        {
            _set = string.Format("{0} = {1}", field, value);
            return this;
        }
    }
}

using System;
using System.Collections.Generic;

namespace Squel
{
    public partial class SelectQuery : QueryBase, IQuery
    {
        

        public SelectQuery()
        {
            _fields = new List<string>();
            _orderBy = new List<string>();
            _from = string.Empty;
            _where = string.Empty;
            _groupBy = string.Empty;
            _limit = 0;
        }

        public SelectQuery(string field) : this()
        {
            _fields.Add(field);
        }

        public SelectQuery Field(string field)
        {
            _fields.Add(field);
            return this;
        }

        public SelectQuery From(string from)
        {
            _from = string.Format("{0}{1}", FROM, from);
            return this;
        }

        public SelectQuery From(string from, string acronimus)
        {
            _from = string.Format("{0}{1} {2}", FROM, from, acronimus);
            return this;
        }

        public SelectQuery Where(string condition)
        {
            _where = string.Format("{0}{1}", WHERE, condition);
            return this;
        }        

        public SelectQuery Limit(int limit)
        {
            _limit = limit;
            return this;
        }

        public SelectQuery OrderBy(string orderBy)
        {
            if (_orderBy.Count > 0)
            {
                _orderBy.Add(string.Format("{0}{1}", ", ", orderBy));
            }
            else
            {
                _orderBy.Add(orderBy);
            }
            return this;
        }

        public SelectQuery Asc()
        {
            _orderBy.Add(ASC);
            return this;
        }

        public SelectQuery Desc()
        {
            _orderBy.Add(DESC);
            return this;
        }

        public SelectQuery GroupBy(string groupBy)
        {
            _groupBy = groupBy;
            return this;
        }

        public string ToSQLString()
        {
            var fields = GetStringFields();
            var orderBy = GetStringOrder();
            var groupBy = GetStringGroup();
            var limit = GetStringLimit();

            return string.Format("{0}{1}{2}{3}{4}{5}{6}", SELECT, fields, _from, _where, groupBy, orderBy, limit);
        }

        
    }
}

using System;
using System.Collections.Generic;

namespace Squel
{
    public partial class SelectQuery : QueryBase, IQuery
    {
        public SelectQuery()
        {
            _distinct = string.Empty;
            _fields = new List<string>();
            _orderBy = new List<string>();
            _from = new List<string>();
            _where = string.Empty;
            _groupBy = string.Empty;
            _limit = 0;
        }

        public SelectQuery(string field) : this()
        {
            _fields.Add(field);
        }

        public SelectQuery Distinct()
        {
            _distinct = DISTINCT;
            return this;
        }

        public SelectQuery Field(string field)
        {
            _fields.Add(field);
            return this;
        }

        public SelectQuery Field(string field, string alias)
        {
            var partialField = string.Format("{0} AS '{1}'", field, alias);
            return Field(partialField);
        }

        public SelectQuery From(string from)
        {
            _from.Add(from);
            return this;
        }

        public SelectQuery From(string from, string acronimus)
        {
            var someFroms = string.Format("{0} {1}", from, acronimus);
            return From(someFroms);
        }

        public SelectQuery From(SelectQuery query, string acronimus)
        {
            var sql = string.Format("{0}{1}{2}", "(", query.ToSQLString(), ")");
            return From(sql, acronimus);
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
            var from = GetStringFrom();
            var orderBy = GetStringOrder();
            var groupBy = GetStringGroup();
            var limit = GetStringLimit();

            return string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}", SELECT, _distinct, fields, FROM ,from, _where, groupBy, orderBy, limit);
        }
    }
}

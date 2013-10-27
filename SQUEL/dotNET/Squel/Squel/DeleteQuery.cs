using System;
using System.Collections.Generic;

namespace Squel
{
    public class DeleteQuery : QueryBase, IQuery
    {
        private const string DELETE = "DELETE ";
        private const string FROM = "FROM ";
        private const string WHERE = " WHERE ";

        private string _from;
        private IList<string> _where;

        public DeleteQuery()
        {
            _from = string.Empty;
            _where = new List<string>();
        }

        public string ToSQLString()
        {
            var where = GetStringWhere();
            return string.Format("{0}{1}{2}{3}", DELETE, FROM, _from, where);
        }

        public DeleteQuery From(string from)
        {
            _from = from;
            return this;
        }

        public DeleteQuery Where(string where)
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
    }
}

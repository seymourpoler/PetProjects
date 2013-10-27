using System;
using System.Text;
using System.Collections.Generic;

namespace Squel
{
    public partial class SelectQuery : QueryBase, IQuery
    {
        private const string SELECT = "SELECT ";
        private const string DISTINCT = "DISTINCT ";
        private const string FROM = " FROM ";
        private const string WHERE = " WHERE ";
        private const string ORDER_BY = " ORDER BY ";
        private const string ASC = " ASC";
        private const string DESC = " DESC";
        private const string GROUP_BY = " GROUP BY ";
        private const string LIMIT = " LIMIT ";
        private const string OFFSET = " OFFSET ";
        private const string JOIN = " INNER JOIN ";
        private const string OUTER_JOIN = " OUTER JOIN ";
        private const string LEFT_JOIN = " LEFT JOIN ";
        private const string RIGHT_JOIN = " RIGHT JOIN ";

        private string _distinct;
        private IList<string> _fields;
        private IList<string> _orderBy;
        private IList<string> _from;
        private IList<string>  _where;
        private IList<string> _groupBy;
        private int _limit;
        private int _offset;
        private string _join;
        private string _outerJoin;
        private string _leftJoin;
        private string _rightJoin;

        private string GetStringFields()
        {
            if (_fields.Count == 0)
            {
                return "*";
            }
            if (_fields.Count == 1)
            {
                return _fields[0];
            }

            return Functions.Map(_fields, ", ");
        }

        private string GetStringFrom()
        {
            return Functions.Map(_from, ", ");
        }

        private string GetStringLimit()
        {
            if (_limit != 0)
            {
                return string.Format("{0}{1}", LIMIT, _limit);
            }
            return string.Empty;
        }

        private string GetStringOffset()
        {
            if (_offset != 0)
            {
                return string.Format("{0}{1}", OFFSET, _offset);
            }
            return string.Empty;
        }

        private string GetStringOrder()
        {
            if (_orderBy.Count == 0)
            {
                return string.Empty;
            }
            var result = new StringBuilder();
            foreach (var order in _orderBy)
            {
                result.Append(order);
            }
            return string.Format("{0}{1}", ORDER_BY, result.ToString());
        }

        private string GetStringGroup()
        {
            var conditions = Functions.Map(_groupBy, ", ");
            return Functions.GetString(GROUP_BY, conditions);
        }

        private string GetStringWhere()
        {
            var conditions = Functions.Map(_where, " AND ");
            return Functions.GetString(WHERE, conditions);
        }

        private string GetStringJoin()
        {
            return Functions.GetString(JOIN, _join);
        }

        private string GetStringOuterJoin()
        {
            return Functions.GetString(OUTER_JOIN, _outerJoin);
        }

        private string GetStringLeftJoin()
        {
            return Functions.GetString(LEFT_JOIN, _leftJoin);
        }

        private string GetStringRightJoin()
        {
            return Functions.GetString(RIGHT_JOIN, _rightJoin);
        }
    }
}

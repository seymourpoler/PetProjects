using System;
using System.Text;
using System.Collections.Generic;

namespace Squel
{
    public partial class SelectQuery
    {
        private const string SELECT = "SELECT ";
        private const string FROM = " FROM ";
        private const string WHERE = " WHERE ";
        private const string ORDER_BY = " ORDER BY ";
        private const string ASC = " ASC";
        private const string DESC = " DESC";
        private const string GROUP_BY = " GROUP BY ";
        private const string LIMIT = " LIMIT ";

        private IList<string> _fields;
        private IList<string> _orderBy;
        private string _from;
        private string _where;
        private int _limit;
        private string _groupBy;

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
            var result = new StringBuilder();
            for (var cont = 0; cont < _fields.Count; cont++)
            {
                result.Append(_fields[cont]);
                if (cont < _fields.Count - 1)
                { result.Append(", "); }
            }

            return result.ToString();
        }

        private string GetStringLimit()
        {
            if (_limit != 0)
            {
                return string.Format("{0}{1}", LIMIT, _limit);
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
            return GetString(GROUP_BY, _groupBy);
        }

        private string GetStringWhere()
        {
            return GetString(WHERE, _where);
        }
    }
}

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
            _where = new List<string>();
            _groupBy = new List<string>();
            _limit = 0;
            _offset = 0;
            _join = string.Empty;
            _outerJoin = string.Empty;
            _leftJoin = string.Empty;
            _rightJoin = string.Empty;
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
            var newCondition = string.Format("({0})", condition);
            _where.Add(newCondition);
            return this;
        }
        public SelectQuery Where(ConditionSentence conditionSentence)
        {
            var sentence = conditionSentence.ToSQLString();
            return Where(sentence);
        }

        public ConditionSentence Expr()
        {
            return new ConditionSentence();
        }

        public SelectQuery Limit(int limit)
        {
            _limit = limit;
            return this;
        }

        public SelectQuery Offset(int offset)
        {
            _offset = offset;
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

        public SelectQuery Group(string groupBy)
        {
            _groupBy.Add(groupBy);
            return this;
        }

        public SelectQuery Join(string join)
        {
            _join = join;
            return this;
        }

        public SelectQuery Join(string join, string alias)
        {
            var simpleJoin = string.Format("{0} {1}", join, alias);
            return Join(simpleJoin);
        }

        public SelectQuery Join(string join, string alias, ConditionSentence conditionSentence)
        {
            var simpleJoin = string.Format("{0} {1} ON ({2})", join, alias, conditionSentence.ToSQLString());
            return Join(simpleJoin);
        }

        public SelectQuery OuterJoin(string outerJoin)
        {
            _outerJoin = outerJoin;
            return this;
        }

        public SelectQuery LeftJoin(string leftJoin, string onLeftJoin)
        {
            _leftJoin = string.Format("{0} ON ({1})", leftJoin, onLeftJoin);
            return this;
        }

        public SelectQuery LeftJoin(string leftJoin, string alias, string onLeftJoin)
        {
            var leftJoinAlias = string.Format("{0} {1}", leftJoin, alias);
            return LeftJoin(leftJoinAlias, onLeftJoin);
        }

        public SelectQuery RightJoin(string rightJoin, string onRightJoin)
        {
            _rightJoin = string.Format("{0} ON ({1})", rightJoin, onRightJoin);
            return this;
        }

        public SelectQuery RightJoin(string rightJoin, string alias, string onRightJoin)
        {
            var rightJoinAlias = string.Format("{0} {1}", rightJoin, alias);
            return RightJoin(rightJoinAlias, onRightJoin);
        }

        public string ToSQLString()
        {
            var fields = GetStringFields();
            var from = GetStringFrom();
            var where = GetStringWhere();
            var orderBy = GetStringOrder();
            var groupBy = GetStringGroup();
            var limit = GetStringLimit();
            var offset = GetStringOffset();
            var join = GetStringJoin();
            var outerJoin = GetStringOuterJoin();
            var leftJoin = GetStringLeftJoin();
            var rightJoin = GetStringRightJoin();

            return string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}", SELECT, _distinct, fields, FROM ,from, where, groupBy, orderBy, limit, join, outerJoin, leftJoin, rightJoin, offset);
        }
    }
}

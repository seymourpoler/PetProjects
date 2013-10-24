using System;
using System.Collections.Generic;

namespace Squel
{
    public class SQL
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

        public UpdateQuery Update()
        {
            query = new UpdateQuery();
            return (UpdateQuery)query;
        }

        public InsertQuery Insert()
        {
            query = new InsertQuery();
            return (InsertQuery)query;
        }

        public DeleteQuery Delete()
        {
            query = new DeleteQuery();
            return (DeleteQuery)query;
        }

        public ConditionSentence Expr()
        {
            query = new ConditionSentence();
            return (ConditionSentence)query;
        }
    }
}

using Gambon.Core;
using System;

namespace Gambon.Sql
{
    public class SqlDeleteBuilder<T> where T : class
    {
        private readonly dynamic condition;

        public SqlDeleteBuilder(dynamic condition)
        {
            this.condition = condition;
        }

        public string ToSql()
        {
            var typeName = typeof(T).Name;
            if (condition == null)
            {
                return "DELETE FROM {0}s".FormatWith(typeName);
            }
            var sqlWhere = new SqlWhereBuilder(condition).Build();
            return String.Format("DELETE FROM {0}s WHERE {1}", typeName, sqlWhere);
        }
    }
}

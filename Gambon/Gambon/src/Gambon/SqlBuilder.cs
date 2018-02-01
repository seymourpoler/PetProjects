using Gambon.Core;
using System.Collections.Generic;

namespace Gambon
{
    public class SqlBuilder
    {
        public string Select<T>(IEnumerable<string> fields = null) where T : class
        {
            return new SqlSelectBuilder<T>(fields)
                .ToSql();
        }

        public string Insert<T>(T entity, dynamic condition = null) where T : class
        {
            return new SqlInsertBuilder<T>(
                    entity: entity,
                    condition: condition)
                .ToSql();
        }

        public string Update<T>(T entity, dynamic condition = null) where T : class
        {
            return new SqlUpdateBuilder<T>(entity)
                .ToSql();
        }

        public string Delete<T>() where T : class
        {
            var typeName = typeof(T).Name;
            return "DELETE FROM {0}s".FormatWith(typeName);
        }
    }
}

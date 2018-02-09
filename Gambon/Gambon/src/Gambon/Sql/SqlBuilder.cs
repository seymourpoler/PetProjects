using System.Collections.Generic;

namespace Gambon.Sql
{
    public class SqlBuilder
    {
        public string Select<T>(IEnumerable<string> fields = null) where T : class
        {
            return new SqlSelectBuilder<T>(
                    fields: fields)
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
            return new SqlUpdateBuilder<T>(
                    entity: entity,
                    condition: condition)
                .ToSql();
        }

        public string Delete<T>(dynamic condition = null) where T : class
        {
            return new SqlDeleteBuilder<T>(
                    condition: condition)
                .ToSql();
        }
    }
}

using System.Collections.Generic;

namespace Gambon.Sql
{
    public interface ISqlBuilder
    {
        string Select<T>(IEnumerable<string> fields = null, dynamic condition = null) where T : class;
        string Insert<T>(T entity, dynamic condition = null) where T : class;
        string Update<T>(T entity, dynamic condition = null) where T : class;
        string Delete<T>(dynamic condition = null) where T : class;
    }

    public class SqlBuilder : ISqlBuilder
    {
        public string Select<T>(IEnumerable<string> fields = null, dynamic condition = null) where T : class
        {
            return new SqlSelectBuilder<T>(
                    fields: fields,
                    condition: condition)
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

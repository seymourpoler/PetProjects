using Gambon.Core;
using System;

namespace Gambon
{
    public class SqlUpdateBuilder<T> where T : class
    {
        private readonly T entity;
        public SqlUpdateBuilder(T entity)
        {
            this.entity = entity;
        }

        public string ToSql()
        {
            if (entity.IsNull())
            {
                return String.Empty;
            }
            throw new NotImplementedException();
        }
    }
}

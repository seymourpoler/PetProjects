﻿using Gambon.Sql;
using System.Collections.Generic;

namespace Gambon.Commands
{
    public interface ISelectCommand
    {
        IEnumerable<T> Execute<T>(IEnumerable<string> fields = null, dynamic condition = null) where T : class;
    }

    public class SelectCommand : ISelectCommand
    {
        private readonly ISqlExecutorWithGeneric sqlExecutor;
        private readonly ISqlBuilder sqlBuilder;

        public SelectCommand(ISqlExecutorWithGeneric sqlExecutor, ISqlBuilder sqlBuilder)
        {
            this.sqlExecutor = sqlExecutor;
            this.sqlBuilder = sqlBuilder;
        }

        public IEnumerable<T> Execute<T>(
            IEnumerable<string> fields = null,
            dynamic condition = null) where T : class
        {
            var sql = sqlBuilder.Select<T>(
                fields: fields,
                condition: condition);
            return sqlExecutor.ExecuteReader<T>(sql);
        }
    }
}

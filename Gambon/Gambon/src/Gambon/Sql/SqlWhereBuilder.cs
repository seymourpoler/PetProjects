using System;
using System.Collections.Generic;

namespace Gambon.Sql
{
    public class SqlWhereBuilder
    {
        private readonly dynamic condition;

        public SqlWhereBuilder(dynamic condition)
        {
            this.condition = condition;
        }

        public string Build()
        {
            var properties = condition.GetType().GetProperties();
            var values = new List<string>();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(condition, null);
                if (property.PropertyType == typeof(string))
                {
                    values.Add(String.Format("{0} = '{1}'", propertyName, propertyValue));
                }
                else
                {
                    values.Add(String.Format("{0} = {1}", propertyName, propertyValue));
                }
            }
            return String.Join(" AND ", values);
        }
    }
}

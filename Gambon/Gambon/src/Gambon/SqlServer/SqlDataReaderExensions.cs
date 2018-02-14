using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;

namespace Gambon.SqlServer
{
    public static class SqlDataReaderExensions
    {
        public static dynamic ToDynamic(this SqlDataReader dataReader)
        {
            dynamic expandoObject = new ExpandoObject();
            var result = expandoObject as IDictionary<string, object>;
            var values = new object[dataReader.FieldCount];
            dataReader.GetValues(values);
            for (var position = 0; position < values.Length; position++)
            {
                result.Add(
                    key: GetNameFrom(dataReader, position),
                    value: GetValue(values, position));
            }
            return result as dynamic;
        }

        private static string GetNameFrom(SqlDataReader dataReader, int position)
        {
            return dataReader.GetName(position);
        }

        private static object GetValueFrom(object value)
        {
            if (DBNull.Value.Equals(value))
            {
                return null;
            }
            return value;
        }

        public static T To<T>(this SqlDataReader dataReader) where T : class, new()
        {
            var instance = Activator.CreateInstance<T>();
            var values = new object[dataReader.FieldCount];
            dataReader.GetValues(values);
            for (var position = 0; position < values.Length; position++)
            {
                var nameField = GetNameFrom(dataReader, position);
                var valueField = GetValue(values, position);
                var property = instance.GetType().GetProperty(nameField);
                property.SetValue(instance, valueField);
            }
            return instance;
        }

        private static object GetValue(object[] values, int position)
        {
            var value = values[position];
            return GetValueFrom(value);
        }
    }
}

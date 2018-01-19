using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace ExtensionMethods
{
    public partial class DynamicConverter
    {
        public static T To<T>(dynamic entity) where T : class
        {
            if (entity == null)
            {
                return null;
            }

            var result = Activator.CreateInstance<T>();
            var properties = result.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (HasProperty(entity, property.Name))
                {
                    var value = property.GetValue(entity, null);
                    property.SetValue(result, value, null);
                }
            }
            return result;
        }
        
        private static bool HasProperty(dynamic entity, string propertyName)
        {
            if (entity is ExpandoObject)
            {
                return ((IDictionary<string, object>) entity).ContainsKey(propertyName);
            }
            return entity.GetType().GetProperty(propertyName) != null;
        }
    }
}

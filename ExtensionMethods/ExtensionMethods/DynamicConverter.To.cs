using System;
using System.Collections.Generic;
using System.Dynamic;

namespace ExtensionMethods
{
    public class DynamicConverter
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
                    var value = GetValue(entity, property.Name);
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

        private static object GetValue(object thing, string propertyName)
        {
            var property = thing.GetType().GetProperty(propertyName);
            if (property == null)
            {
                return null;
            }
            return property.GetValue(thing, null);
        }
    }
}

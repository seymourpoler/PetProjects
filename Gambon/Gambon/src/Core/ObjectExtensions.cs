using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.Linq;

namespace Gambon.Core
{
	public static class ObjectExtensions
	{
        public static dynamic ToDynamic(this object thing)
        {
			if (thing is ExpandoObject)
				return thing;
            var expando = new ExpandoObject();
            var result = expando as IDictionary<string, object>; 
            if (IsNameValueCollection(thing)) {
                var nameValueCollection = (NameValueCollection)thing;
				nameValueCollection.Cast<string>()
                	.Select(key => new KeyValuePair<string, object>(key, nameValueCollection[key]))
                	.ToList()
                	.ForEach(result.Add);
                return result;
            }
            if (IsDictionary(thing))
			{
                var nameValueCollection = (Dictionary <string, object>)thing;
                nameValueCollection
                    .ToList()
					.ForEach(result.Add);
				return result;
			}
			var properties = thing.GetType().GetProperties();
                foreach (var property in properties) {
                    result.Add(property.Name, property.GetValue(thing, null));
                }
            return result;
        }

        public static bool IsNull(this object thing){
        	return thing == null;
        }

        private static bool IsNameValueCollection(object thing){
        	return thing.GetType() == typeof(NameValueCollection) || 
        		thing.GetType().IsSubclassOf(typeof(NameValueCollection));
        }

        private static bool IsDictionary(object thing){
            	return typeof(IDictionary).IsAssignableFrom(thing.GetType());
            }

		public static IDictionary<string, object> ToDictionary(this object thing) {
            if(thing == null){
                return null;
            }
            return (IDictionary<string, object>)thing.ToDynamic();
        }
	}
}

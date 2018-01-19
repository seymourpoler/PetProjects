﻿using System;
using System.Collections.Generic;
using System.Dynamic;

namespace ExtensionMethods
{
    public static partial class ObjectExtensions
    {
        public static dynamic ToDynamic<T>(this T entity)
        {
            if (entity.IsNull())
            {
                return entity;
            }
            var dynamicObject = new ExpandoObject() as IDictionary<string, Object>;
            foreach (var propertyInfo in typeof(T).GetProperties())
            {
                var currentPropertyName = propertyInfo.Name;
                var currentPropertyValue = propertyInfo.GetValue(entity, null);
                dynamicObject.Add(currentPropertyName, currentPropertyValue);
            }
            return dynamicObject;
        }
    }
}

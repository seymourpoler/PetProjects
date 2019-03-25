using System;
using System.Reflection;

namespace JasmineDotNet.Extensions
{
    public static class TypeExtensions
    {
        public static T CreateInstanceAs<T>(this Type type) where T : class
        {
            return type.GetTypeInfo().GetConstructors()[0].Invoke(new object[0]) as T;
        }
    }
}
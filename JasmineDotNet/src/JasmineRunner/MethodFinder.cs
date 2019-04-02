using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace JasmineRunner
{
    public class MethodFinder
    {
        public IReadOnlyCollection<MethodInfo> Find(Type type)
        {
            var result = type
                .GetTypeInfo()
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly)
                .Where(x => x.Name.ToUpper().Contains("it".ToUpper()))
                .ToList()
                .AsReadOnly();
            
            return result;
        }
    }
}
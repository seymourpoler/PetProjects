using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace JasmineDotNet
{
    public class MethodFinder
    {
        public IReadOnlyCollection<Context> Find(Type type)
        {
            var result = new List<Context>();
            foreach (var method in FindMethods(type))
            {
                result.Add(new MethodContext(method));
            }
            return result.AsReadOnly();            
        }
        
        IReadOnlyCollection<MethodInfo> FindMethods(Type type)
        {
            const int noParameters = 0;
            var result = type
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly    )
                .Where(x => x.ReturnType == typeof(void))
                .Where(x => x.GetParameters().Length == noParameters)
                .OrderBy((x => x.Name))
                .ToList()
                .AsReadOnly();

            return result;
        }
    }
}
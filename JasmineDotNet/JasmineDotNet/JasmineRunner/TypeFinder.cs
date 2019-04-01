using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using JasmineDotNet;
using JasmineDotNet.Extensions;

namespace JasmineRunner
{
    public class TypeFinder
    {
        public IReadOnlyCollection<Type> find(string filePath)
        {
            var assemblyName = Path.GetFileNameWithoutExtension(filePath);
            var assembly = Assembly.Load(new AssemblyName(assemblyName));
            var types = assembly.GetTypes();

            var result = types.Where(t => 
                t.GetTypeInfo().IsClass
                && !t.GetTypeInfo().IsAbstract
                && BaseTypes(t).Any(s => s == typeof(Jasmine)));
            
            return result.OrderBy(x => x.Name).ToList().AsReadOnly();
        }

        IEnumerable<Type> BaseTypes(Type type)
        {
            var types = new List<Type>();

            var currentType = type.GetTypeInfo().BaseType;

            while (currentType.IsNotNull())
            {
                types.Add(currentType);
                currentType = currentType.GetTypeInfo().BaseType;
            }

            return types;
        }
    }
}
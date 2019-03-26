using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using JasmineDotNet;

namespace JasmineRunner
{
    public class TypeFinder
    {
        public IReadOnlyCollection<Type> find(string filePath)
        {
            var assemblyPath = Path.GetFullPath(filePath);
            var assemblyName = Path.GetFileNameWithoutExtension(filePath);
            var assembly = Assembly.Load(new AssemblyName(assemblyName));
            var types = assembly.GetTypes();
//            var result = types.Where(t => t.GetTypeInfo().IsClass
//                                 && !t.GetTypeInfo().IsAbstract
//                                 && BaseTypes(t).Any(s => s == typeof(Jasmine))
//                                 && (Methods(t).Any()));

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
        
        IEnumerable<MethodInfo> Methods(Type type)
        {
            var flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly;

            var exclusions = typeof(Jasmine).GetTypeInfo().GetMethods(flags).Select(m => m.Name);

            var methodInfos = GetAbstractBaseClassChainWithClass(type).SelectMany(t => t.GetTypeInfo().GetMethods(flags));

            return methodInfos
                .Where(m => !exclusions.Contains(m.Name) && !(m.Name.Contains("<") || m.Name.Contains("$")) && m.Name.Contains("_"))
                .Where(m => m.GetParameters().Length == 0)
                .Where(m => m.ReturnType == typeof(void)).ToList();
        }
        
        IEnumerable<Type> GetAbstractBaseClassChainWithClass(Type type)
        {
            var baseClasses = new Stack<Type>();

            for (Type baseClass = type.GetTypeInfo().BaseType;
                baseClass != null && baseClass.GetTypeInfo().IsAbstract;
                baseClass = baseClass.GetTypeInfo().BaseType)
            {
                baseClasses.Push(baseClass);
            }

            while (baseClasses.Count > 0) yield return baseClasses.Pop();

            yield return type;
        }
    }
}
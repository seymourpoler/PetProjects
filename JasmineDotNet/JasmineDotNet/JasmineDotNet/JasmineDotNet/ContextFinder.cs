using System;
using System.Collections.Generic;
using System.Reflection;

namespace JasmineDotNet
{
    public class ContextFinder
    {
        public IReadOnlyCollection<Context> Find(Type type)
        {
            if (type.IsNull())
            {
                return new[]{ Context.CreateEmpty()};
            }

            var result = new List<Context>();
            foreach (var method in type.GetMethods())
            {
                result.Add(new MethodContext(method));
            }

            return result;
        }
    }
}

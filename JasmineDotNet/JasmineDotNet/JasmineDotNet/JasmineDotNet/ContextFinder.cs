using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JasmineDotNet.Extensions;

namespace JasmineDotNet
{
    public class ContextFinder
    {
        private readonly ClassFinder classFinder;
        public ContextFinder(ClassFinder  classFinder)
        {
            this.classFinder = classFinder;
        }

        public Context Find(Type type)
        {
            if (type.IsNull())
            {
                return Context.CreateEmpty();
            }

            var context = classFinder.Find(type);
            var instance = type.CreateInstanceAs<Jasmine>();
            context.Build(instance);

            return context;
        }
    }
}

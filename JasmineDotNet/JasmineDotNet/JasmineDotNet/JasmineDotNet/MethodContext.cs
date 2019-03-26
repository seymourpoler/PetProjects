using System;
using System.Linq;
using System.Reflection;

namespace JasmineDotNet
{
    public class MethodContext : Context
    {
        private MethodInfo method;

        public MethodContext(MethodInfo method)
        : base(method.Name)
        {
            this.method = method;
        }

        public override void Build(Jasmine instance)
        {
            base.Build(instance);
            method.Invoke(instance, null);
            for (var position = 0; position < Contexts.Count(); position++)
            {
                Contexts[position].Build(instance);
            }
        }
    }
}
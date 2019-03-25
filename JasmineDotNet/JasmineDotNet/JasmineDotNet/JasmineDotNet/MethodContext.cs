using System;
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
    }
}
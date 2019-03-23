using System;
using System.Reflection;

namespace JasmineDotNet
{
    public class ContextFinder
    {
        public Context Find(MethodInfo method)
        {
            if (method.IsNull())
            {
                return Context.CreateEmpty();
            }
            
            return new Context(method.Name, method.GetMethsodBody());
            
        }
    }
}

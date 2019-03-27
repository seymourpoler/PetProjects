using System;

namespace JasmineDotNet
{
    public class ClassFinder
    {
        private readonly MethodFinder methodFinder;

        public ClassFinder(MethodFinder methodFinder)
        {
            this.methodFinder = methodFinder;
        }

        public Context Find(Type type)
        {
            var result = new Context(type.Name);
            foreach (var methodContext in methodFinder.Find(type))
            {
                result.AddContext(methodContext);
            }
            
            
            
            return result;
        }
    }
}
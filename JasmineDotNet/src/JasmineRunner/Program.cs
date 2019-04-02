using JasmineDotNet;

namespace JasmineRunner
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var path = args[0];
            var typeFinder = new TypeFinder();
            var contextFinder = new SpecificationFinder(new ClassFinder(new MethodFinder()));
            var specWritter = new SpecificationWritter(new ConsoleWritter());
            
            var types = typeFinder.find(path);
            var context = new Specification(path);
            foreach (var type in types)
            {
                var currentContext = contextFinder.Find(type);
                context.AddContext(currentContext);
            }
            specWritter.Write(context);
        }
    }
}
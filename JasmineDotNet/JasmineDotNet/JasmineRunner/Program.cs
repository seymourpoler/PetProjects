using JasmineDotNet;

namespace JasmineRunner
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //var path = "SampleSpec.dll";
            var path = args[0];
            var typeFinder = new TypeFinder();
            var contextFinder = new ContextFinder(new ClassFinder(new MethodFinder()));
            var specWritter = new SpecWritter(new ConsoleWritter());
            
            var types = typeFinder.find(path);
            foreach (var type in types)
            {
                var context = contextFinder.Find(type);    
                specWritter.Write(context);
            }
        }
    }
}
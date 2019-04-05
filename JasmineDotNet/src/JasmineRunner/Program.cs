using JasmineDotNet;

namespace JasmineRunner
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var path = args[0];
            var typeFinder = new TypeFinder();
            var specificationFinder = new SpecificationFinder(new ClassFinder(new MethodFinder()));
            var specificationWritter = new SpecificationWritter(new ConsoleWritter());
            
            var types = typeFinder.find(path);
            var specification = new Specification(path);
            foreach (var type in types)
            {
                var currentSpecification = specificationFinder.Find(type);
                specification.AddContext(currentSpecification);
            }
            specificationWritter.Write(specification);
        }
    }
}
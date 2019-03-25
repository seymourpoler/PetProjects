namespace JasmineRunner
{
    public class SpecRunner
    {
        readonly SpecFinder specFinder;

        public SpecRunner(SpecFinder specFinder)
        {
            this.specFinder = specFinder;
        }

        public void Run(string filePath)
        {
            var specifications = specFinder.find(filePath);
        }
    }
}
using JasmineDotNet;

namespace SampleSpec
{
    public class SimpleTest : Jasmine
    {
        public void a_test()
        {
            it("a simple test", () => { expect("").ToBeNull(); });
        }
    }
}
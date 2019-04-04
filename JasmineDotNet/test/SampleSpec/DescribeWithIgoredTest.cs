using JasmineDotNet;

namespace SampleSpec
{
    public class DescribeWithIgoredTest : Jasmine
    {
        public void method_with_describe_an_ignored_test()
        {
            describe("a describe with ignore test", () =>
            {
                xit("ignored test", () => { throw new System.Exception(); });
            });
        }
    }
}
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
        
        public void method_with_ignored_describe_an_a_test()
        {
            xdescribe("a describe with ignore test", () =>
            {
                it("ignored test", () => { throw new System.Exception(); });
            });
        }
        
        public void method_with_ignored_describe_an_ignored_test()
        {
            xdescribe("a describe with ignore test", () =>
            {
                xit("ignored test", () => { throw new System.Exception(); });
            });
        }
        
        public void method_with_ignored_describe_and_another_describe_and_a_test()
        {
            xdescribe("a describe with ignore test", () =>
            {
                describe("another describe", () =>
                {
                    it("ignored test", () => { throw new System.Exception(); }); 
                });
            });
        }
    }
}
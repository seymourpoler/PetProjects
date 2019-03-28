using JasmineDotNet;

namespace SampleSpec
{
    public class SimpleTest : Jasmine
    {
        public void a_fail_test()
        {
            it("the test", () => { expect("").ToBeNull(); });
        }
        
        public void a_success_test()
        {
            it("the test", () => { expect<string>(null).ToBeNull(); });
        }
        
        public void a_describe_with_a_fail_test()
        {
            describe("the describe of a fail test", () =>
            {
                it("the test", () => { expect("").ToBeNull(); }); 
            });
        }
        
        public void a_describe_with_a_success_test()
        {
            describe("the describe of a success test", () =>
            {
                it("the test", () => { expect<string>(null).ToBeNull(); }); 
            });
        }
    }
}
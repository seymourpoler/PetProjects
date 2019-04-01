using JasmineDotNet;

namespace SampleSpec
{
    public class DescribeWithTestAndAfterAll : Jasmine
    {
        public void a_describe_with_a_success_test_and_after_all_method()
        {
            describe("the describe of a success test with after all method", () =>
            {
                beforeAll(() => { expect(true).ToBe(true);});
                it("a test", () => {expect(false).ToBe(true);});
            });
        }
        
        public void a_describe_with_a_fail_test_and_after_all_method()
        {          
            describe("the describe of a fail test with after all method", () =>
            {
                beforeAll(() => { expect(true).ToBe(true); });
                it("a test", () => {expect(true).ToBe(true);});
            });
        }
    }
}
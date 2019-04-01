using JasmineDotNet;

namespace SampleSpec
{
    public class DescribeWithTestAndAfterEach : Jasmine
    {
        public void a_describe_with_a_success_test_and_afterEach_method()
        {
            describe("the describe of a success test with after each method", () =>
            {
                var value = 2;
                afterEach(() => { value++;});
                it("the test with for each for each method", () => { expect(value).ToBe(2); });
                it("another test with for each for each method", () => { expect(value).ToBe(1); });
            });
        }
        
        public void a_describe_with_a_fail_test_and_afterEach_method()
        {
            describe("the describe of a fail test with after each method", () =>
            {
                var value = 0;
                afterEach(() => { value++;});
                it("the test with for each for each method", () => { expect(value).ToBe(2); });
                it("another test with for each for each method", () =>
                {
                    expect(value).ToBe(1);
                    expect("").ToBeNull();
                });
            });
        }
    }
}
using JasmineDotNet;

namespace SampleSpec
{
    public class DescribeWithTestAndBeforeAll : Jasmine
    {
        public void a_describe_with_a_success_test_and_forEach_method()
        {
            describe("the describe of a success test with for each method", () =>
            {
                var beforeAllWasThrough = false;
                beforeAll(() => { beforeAllWasThrough = true;});

                var value = 0;
                beforeEach(() => { value++;});
                it("the test with for each for each method", () => { expect(value).ToBe(1); });
                it("another test with for each for each method", () => { expect(value).ToBe(2); });
                it("before all has to be throguthn", () => {expect(beforeAllWasThrough).ToBe(true);});
            });
            
            describe("the describe of a fail test with for each method", () =>
            {
                var beforeAllWasThrough = false;
                beforeAll(() => { beforeAllWasThrough = true;});

                var value = 0;
                beforeEach(() => { value++;});
                it("the test with for each for each method", () => { expect(true).ToBe(false); });
                it("another test with for each for each method", () => { expect(value).ToBe(2); });
                it("before all has to be throguthn", () => {expect(beforeAllWasThrough).ToBe(true);});
            });
        }
    }
}
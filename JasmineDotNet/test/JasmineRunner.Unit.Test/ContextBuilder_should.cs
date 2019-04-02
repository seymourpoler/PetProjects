using Xunit;
using JasmineDotNet;

namespace JasmineRunner.Unit.Test
{
    public class ContextBuilder_should
    {
        [Fact]
        public void return_context_when_there_is_a_method_and_a_test()
        {
            
        }

        class SpecWithOneMethodAndOneTest : Jasmine
        {
            public void method()
            {
                it("test", () => { expect("").ToBeNull();});
            }
        }
    }
}
using System;
using Xunit;
using Shouldly;

namespace JasmineDotNet.Unit.Test
{
    public class JasmineShould
    {
        [Fact]
        public void throw_argument_null_exception_when_test_suite_name_is_null()
        {
            Action testSuite = () => { var a = 2; };

            Action action = () => new Jasmine().Describe(null,testSuite);

            action.ShouldThrow<ArgumentNullException>();

        }
    }
}
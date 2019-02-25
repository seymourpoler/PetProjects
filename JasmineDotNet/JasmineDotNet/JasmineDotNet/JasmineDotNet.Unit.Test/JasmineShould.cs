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

            Action action = () => new Jasmine().Describe(null, testSuite);

            action.ShouldThrow<ArgumentNullException>();
        }
        
        [Fact]
        public void throw_arguments_exception_when_test_suite_name_is_string_empty()
        {
            Action testSuite = () => { var a = 2; };

            Action action = () => new Jasmine().Describe(String.Empty, testSuite);

            action.ShouldThrow<ArgumentNullException>();
        }
        
        [Fact]
        public void throw_argument_null_exception_when_test_suite_is_null()
        {
            Action action = () => new Jasmine().Describe("test suite name", null);

            action.ShouldThrow<ArgumentNullException>();
        }
    }
}
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

        [Fact]
        public void throw_argument_null_exception_when_before_all_method_is_null()
        {
            var jasmine = new Jasmine();
            
            Action action = () =>
            {
                jasmine.Describe("test suite name", () => { jasmine.BeforeAll(null); });
            };

            action.ShouldThrow<ArgumentNullException>();
        }
        
        //[Fact]
        public void execute_before_all_method_before_all_tests()
        {
            var beforeAllWasFired = false;
            var jasmine = new Jasmine();
            
            jasmine.Describe("test suite name", () => { jasmine.BeforeAll(() => { beforeAllWasFired = true; }); });

            beforeAllWasFired.ShouldBeTrue();
        }

        [Fact]
        public void throw_argument_null_exception_when_test_name_is_null()
        {
            var jasmine = new Jasmine();
            
            Action action = () =>
            {
                jasmine.Describe("test suite name", () =>
                {
                    jasmine.It(null, () =>
                    {
                        var wasFired = true;
                    });
                });
            };

            action.ShouldThrow<ArgumentNullException>();
        }
        
        [Fact]
        public void throw_argumen_null_exception_when_test_name_is_string_empty()
        {
            var jasmine = new Jasmine();
            
            Action action = () =>
            {
                jasmine.Describe("test suite name", () =>
                {
                    jasmine.It(null, () =>
                    {
                        var wasFired = true;
                    });
                });
            };

            action.ShouldThrow<ArgumentNullException>();
        }
        
        [Fact]
        public void throw_argumen_null_exception_when_test_is_null()
        {
            var jasmine = new Jasmine();
            
            Action action = () =>
            {
                jasmine.Describe("test suite name", () =>
                {
                    jasmine.It("test", null);
                });
            };

            action.ShouldThrow<ArgumentNullException>();
        }
        
        [Fact]
        public void execute_a_test()
        {
            var testWasRun = false;
            var jasmine = new Jasmine();
            
            jasmine.Describe("test suite name", () =>
            {
                jasmine.It("test", () => { testWasRun = true; });
            });

            testWasRun.ShouldBeTrue();
        }

        [Fact]
        public void throw_null_argument_exception_when_before_each_is_null()
        {
            var jasmine = new Jasmine();
            
            Action action = () => jasmine.Describe("test suite name", () =>
            {
                jasmine.BeforeEach(null);
                jasmine.It("test", () => {  });
            });

            action.ShouldThrow<ArgumentNullException>();
        }
    }
}
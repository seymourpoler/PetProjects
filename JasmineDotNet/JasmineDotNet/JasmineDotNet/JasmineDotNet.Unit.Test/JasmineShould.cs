﻿using System;
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
        
        [Fact]
        public void execute_before_all_method_before_all_tests()
        {
            var beforeAllWasFired = false;
            var numberOfExecutions = 0;                
            var jasmine = new Jasmine();
            
            jasmine.Describe("test suite name", () =>
            {
                jasmine.BeforeAll(() => { 
                    beforeAllWasFired = true;
                    numberOfExecutions++;
                });
                jasmine.It("a simple test", () => { var wasFired = true; });
            });

            beforeAllWasFired.ShouldBeTrue();
            numberOfExecutions.ShouldBe(1);
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
        
        [Fact]
        public void execute_before_each_test()
        {
            const int totalNumberOfTests = 2;
            var numberOfExecutedTests = 0;
            var jasmine = new Jasmine();
            
            jasmine.Describe("test suite name", () =>
            {
                jasmine.BeforeEach(() => { numberOfExecutedTests++; });
                jasmine.It("test", () => { var @true = true; });
                numberOfExecutedTests.ShouldBe(1);
                jasmine.It("test", () => { var @false = false; });
            });

            numberOfExecutedTests.ShouldBe(totalNumberOfTests);
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
        public void throw_argument_null_exception_when_test_name_is_string_empty()
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
        public void throw_argument_null_exception_when_test_is_null()
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

            jasmine.Describe("test suite name", () => { jasmine.It("test", () => { testWasRun = true; }); });

            testWasRun.ShouldBeTrue();
        }
        
        [Fact]
        public void throw_null_argument_exception_when_after_each_is_null()
        {
            var jasmine = new Jasmine();
            
            Action action = () => jasmine.Describe("test suite name", () =>
            {
                jasmine.AfterEach(null);
            });

            action.ShouldThrow<ArgumentNullException>();
        }
        
        [Fact]
        public void execute_after_each_test()
        {
            const int totalNumberOfTests = 2;
            var numberOfExecutedTests = 0;
            var jasmine = new Jasmine();
            
            jasmine.Describe("test suite name", () =>
            {
                jasmine.AfterEach(() => { numberOfExecutedTests++; });
                jasmine.It("test", () => { var @true = true; });
                numberOfExecutedTests.ShouldBe(1);
                jasmine.It("test", () => { var @false = false; });
            });

            numberOfExecutedTests.ShouldBe(totalNumberOfTests);
        }
        
        [Fact]
        public void throw_argument_null_exception_when_after_all_method_is_null()
        {
            var jasmine = new Jasmine();
            
            Action action = () =>
            {
                jasmine.Describe("test suite name", () => { jasmine.AfterAll(null); });
            };

            action.ShouldThrow<ArgumentNullException>();
        }
        
        [Fact]
        public void execute_after_all_method_afeter_all_tests()
        {
            var wasExecutedAfterAll = false;
            var jasmine = new Jasmine();
            
            jasmine.Describe("test suite name", () =>
            {
                jasmine.AfterAll(() => { wasExecutedAfterAll = true; });
                jasmine.It("a simple test", () => { });
                wasExecutedAfterAll.ShouldBeFalse();
                jasmine.It("a simple test", () => {  });
            });

            wasExecutedAfterAll.ShouldBeTrue();
        }

        [Fact]
        public void do_not_execute_when_is_xdecribe()
        {
            var wasExecuted = false;
            var jasmine = new Jasmine();
            jasmine.XDescribe("test suite name", () =>
            {
                jasmine.It("a simple test", () => { wasExecuted = true;});
            });
            
            wasExecuted.ShouldBeFalse();
        }
    }
}
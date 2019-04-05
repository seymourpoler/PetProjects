using System.Linq;
using JasmineDotNet.Extensions;
using Xunit;
using Shouldly;

namespace JasmineDotNet.Unit.Test
{
    public class SpecificationFinder_should
    {
        private SpecificationFinder finder;

        public SpecificationFinder_should()
        {
            finder = new SpecificationFinder(new ClassFinder(new MethodFinder())); 
        }  
        
        [Fact]
        public void return_empty_context_when_type_is_null()
        {
            var result = finder.Find(null);

            result.Tests.ShouldBeEmpty();
            result.Specifications.ShouldBeEmpty();
        }

        [Fact]
        public void return_empty_context_when_there_is_no_methods()
        {
            var result = finder.Find(typeof(ClassWithNoMethods));

            result.Name.ShouldBe(nameof(ClassWithNoMethods));
            result.Specifications.ShouldBeEmpty();
            result.Tests.ShouldBeEmpty();
        }
        class ClassWithNoMethods: Jasmine { }
        
        [Fact]
        public void return_context_when_there_is_one_method()
        {
            var result = finder.Find(typeof(ClassWithOneMethod));

            result.Name.ShouldBe(nameof(ClassWithOneMethod));
            result.Tests.ShouldBeEmpty();
            result.Specifications.First().Name.ShouldBe("a_test_method");
            result.Specifications.First().Tests.ShouldBeEmpty();
        }
        class ClassWithOneMethod : Jasmine { public void a_test_method(){} }
        
        [Fact]
        public void return_context_when_there_is_one_method_and_one_test()
        {
            var result = finder.Find(typeof(ClassWithOneMethodAndOneTest));

            result.Name.ShouldBe(nameof(ClassWithOneMethodAndOneTest));
            result.Specifications.First().Name.ShouldBe("a_test_method");
            result.Specifications.First().Tests.First().Name.ShouldBe("a test");
        }
        class ClassWithOneMethodAndOneTest : Jasmine
        {
            public void a_test_method()
            {
                it("a test", () =>{ var test = "a test"; });
            }
        }
        
        [Fact]
        public void return_context_when_there_is_one_method_describe_and_one_test()
        {
            var result = finder.Find(typeof(ClassWithOneMethodOneDescribeAndOneTest));

            result.Name.ShouldBe(nameof(ClassWithOneMethodOneDescribeAndOneTest));
            result.Specifications.First().Name.ShouldBe("a_test_method");
            result.Specifications.First().Specifications.First().Name.ShouldBe("a describe");
            result.Specifications.First().Specifications.First().Tests.First().Name.ShouldBe("a test");
        }

        class ClassWithOneMethodOneDescribeAndOneTest : Jasmine
        {
            public void a_test_method()
            {
                describe("a describe", () =>
                {
                    it("a test", () =>
                    {
                        var test = "a test";
                    });
                });
            }
        }
        
        [Fact]
        public void return_context_when_there_is_one_method_with_two_test_and_describe_with_one_test()
        {
            var result = finder.Find(typeof(ClassWithOneMethodWithTestsAndOneDescribeAndOneTest));

            result.Name.ShouldBe(nameof(ClassWithOneMethodWithTestsAndOneDescribeAndOneTest));
            result.Specifications.First().Name.ShouldBe("a_test_method");
            result.Specifications.First().Tests.First().Name.ShouldBe("first test");
            result.Specifications.First().Tests.Second().Name.ShouldBe("second test");
            result.Specifications.First().Specifications.First().Name.ShouldBe("a describe");
            
        }
        class ClassWithOneMethodWithTestsAndOneDescribeAndOneTest : Jasmine
        {
            public void a_test_method()
            {
                describe("a describe", () =>
                {
                    it("a test", () => { var test = "a test"; });
                });

                it("first test", () => { var test = "a test"; });
                
                it("second test", () => { var test = "za test"; });
            }
        }
        
        [Fact]
        public void return_context_describe_with_another_describe_inside()
        {
            var result = finder.Find(typeof(ClassWithDescribeWithAnotherDescribeInside));

            result.Name.ShouldBe(nameof(ClassWithDescribeWithAnotherDescribeInside));
            result.Specifications.First().Name.ShouldBe("a_test_method");
            result.Specifications.First().Specifications.First().Name.ShouldBe("a describe");
            result.Specifications.First().Specifications.First().Specifications.First().Name.ShouldBe("a describe inside");
            result.Specifications.First().Specifications.First().Specifications.First().Tests.First().Name.ShouldBe("a test");

        }
        class ClassWithDescribeWithAnotherDescribeInside : Jasmine
        {
            public void a_test_method()
            {
                describe("a describe", () =>
                {
                    describe("a describe inside", () =>
                    {
                        it("a test", () => { expect<string>("h").ToBeNull(); });    
                    });
                });
            }
        }
    }
}

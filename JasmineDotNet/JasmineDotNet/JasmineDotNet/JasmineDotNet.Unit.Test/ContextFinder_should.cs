using System.Linq;
using Xunit;
using Shouldly;

namespace JasmineDotNet.Unit.Test
{
    public class ContextFinder_should
    {
        private ContextFinder finder;

        public ContextFinder_should()
        {
            finder = new ContextFinder(new ClassFinder(new MethodFinder())); 
        }  
        
        [Fact]
        public void return_empty_context_when_type_is_null()
        {
            var result = finder.Find(null);

            result.Name.ShouldBeEmpty();
        }

        [Fact]
        public void return_empty_context_when_there_is_no_methods()
        {
            var result = finder.Find(typeof(ClassWithNoMethods));

            result.Name.ShouldBeEmpty();
        }

        [Fact]
        public void return_context_when_there_is_one_method()
        {
            var result = finder.Find(typeof(ClassWithOneMethod));

            result.Contexts.First().Name.ShouldBe("a_test");
            result.Tests.ShouldBeEmpty();
        }
        
        [Fact]
        public void return_context_when_there_is_one_method_and_one_test()
        {
            var result = finder.Find(typeof(ClassWithOneMethodAndOneTest));

            result.Name.ShouldBe("a_test");
            result.Tests.First().Name.ShouldBe("a test");
        }

        class ClassWithNoMethods { }

        class ClassWithOneMethod
        {
            public void a_test()
            {
            }
        }
        
        class ClassWithOneMethodAndOneTest : Jasmine
        {
            public void a_test()
            {
                it("a test", () =>{ var test = "a test"; });
            }
        }
    }
}

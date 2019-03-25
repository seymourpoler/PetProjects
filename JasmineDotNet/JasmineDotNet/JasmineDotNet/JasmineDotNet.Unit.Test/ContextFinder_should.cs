using System.Linq;
using Xunit;
using Shouldly;

namespace JasmineDotNet.Unit.Test
{
    public class ContextFinder_should
    {
        [Fact]
        public void return_empty_context_when_type_is_null()
        {
            var finder = new ContextFinder();

            var result = finder.Find(null);

            result.ShouldBeEmpty();
        }

        [Fact]
        public void return_empty_context_when_there_is_no_methods()
        {
            var finder = new ContextFinder();

            var result = finder.Find(typeof(ClassWithNoMethods));

            result.ShouldBeEmpty();
        }

        [Fact]
        public void return_context_when_there_is_one_method()
        {
            var finder = new ContextFinder();

            var result = finder.Find(typeof(ClassWithOneMethod));

            result.First().Contexts.First().Name.ShouldBe("a_test");
            result.First().Tests.ShouldBeEmpty();
        }

        class ClassWithNoMethods { }

        class ClassWithOneMethod
        {
            public void a_test()
            {
            }
        }
    }
}

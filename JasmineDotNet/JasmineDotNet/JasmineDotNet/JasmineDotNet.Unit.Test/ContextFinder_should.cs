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

            result.Contexts.ShouldBeEmpty();
            result.Tests.ShouldBeEmpty();
        }

        [Fact]
        public void return_empty_context_when_there_is_no_methods()
        {
            var finder = new ContextFinder();

            var result = finder.Find(typeof(ClassWithNoMethods));

            result.Contexts.ShouldBeEmpty();
            result.Tests.ShouldBeEmpty();
        }

        class ClassWithNoMethods { }
    }
}

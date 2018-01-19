using System.Collections.Generic;
using ExtensionMethods;
using Shouldly;
using Xunit;

namespace ExtensionMethodsTests
{
    public class ReadOnlyCollectionExtensionsTests
    {
        [Fact]
        public void ReturnTrueWhenIsNull()
        {
            IReadOnlyCollection<string> values = null;

            var result = values.IsEmpty();
            
            result.ShouldBeTrue();
        }
    }
}
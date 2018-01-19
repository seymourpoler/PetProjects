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
        
        [Fact]
        public void ReturnTrueWhenIsEmpty()
        {
            var values = new List<string>().AsReadOnly();

            var result = values.IsEmpty();
            
            result.ShouldBeTrue();
        }
        
        [Fact]
        public void ReturnFalseWhenIsNull()
        {
            IReadOnlyCollection<string> values = null;

            var result = values.IsNotEmpty();
            
            result.ShouldBeFalse();
        }
        
        [Fact]
        public void ReturnFalseWhenIsEmpty()
        {
            var values = new List<string>().AsReadOnly();

            var result = values.IsNotEmpty();
            
            result.ShouldBeFalse();
        }
        
        [Fact]
        public void ReturnsTrueWhenIsNull()
        {
            IReadOnlyCollection<string> values = null;

            var result = values.IsNullOrEmpty();

            result.ShouldBeTrue();
        }
        
        [Fact]
        public void ReturnsTrueWhenIsEmpty()
        {
            var values = new List<string>().AsReadOnly();

            var result = values.IsNullOrEmpty();

            result.ShouldBeTrue();
        }
    }
}
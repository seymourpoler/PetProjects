using System;
using ExtensionMethods;
using Shouldly;
using Xunit;

namespace ExtensionMethodsTests
{
    public class StringExtensionsIsNullOrWhiteSpaceTests
    {
        [Fact]
        public void ReturnsTrueWhenIsNull()
        {
            string text = null;
            
            var result = text.IsNullOrWhiteSpace();

            result.ShouldBeTrue();
        }
        
        [Fact]
        public void ReturnsTrueWhenIsEmpty()
        {
            string text = String.Empty;
            
            var result = text.IsNullOrWhiteSpace();

            result.ShouldBeTrue();
        }
        
        [Fact]
        public void ReturnsTrueWhenIsStringWhiteSpace()
        {
            string text = " ";
            
            var result = text.IsNullOrWhiteSpace();

            result.ShouldBeTrue();
        }

        [Fact]
        public void ReturnsFalseWhenIsNull()
        {
            string text = null;

            var result = text.IsNotNullAndNotWhiteSpace();
            
            result.ShouldBeFalse();
        }
        
        [Fact]
        public void ReturnsFalseWhenIsEmpty()
        {
            string text = String.Empty;

            var result = text.IsNotNullAndNotWhiteSpace();
            
            result.ShouldBeFalse();
        }

        [Fact]
        public void ReturnsFalseWhenIsWhiteSpace()
        {
            string text = " ";

            var result = text.IsNotNullAndNotWhiteSpace();
            
            result.ShouldBeFalse();
        }
    }
}
using System;
using ExtensionMethods;
using ExtensionMethods.String;
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

        [Fact]
        public void ReturnsBuiltText()
        {
            var text = "valueOne: {0}, valueTwo: {1}";

            var result = text.Build(text, "name", "age");
            
            result.ShouldBe("valueOne: name, valueTwo: age");
        }
    }
}
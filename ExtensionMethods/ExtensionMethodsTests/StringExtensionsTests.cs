using System;
using System.Runtime.CompilerServices;
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
            var text = String.Empty;
            
            var result = text.IsNullOrWhiteSpace();

            result.ShouldBeTrue();
        }
        
        [Fact]
        public void ReturnsTrueWhenIsStringWhiteSpace()
        {
            var text = " ";
            
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
            var text = String.Empty;

            var result = text.IsNotNullAndNotWhiteSpace();
            
            result.ShouldBeFalse();
        }

        [Fact]
        public void ReturnsFalseWhenIsWhiteSpace()
        {
            const string text = " ";

            var result = text.IsNotNullAndNotWhiteSpace();
            
            result.ShouldBeFalse();
        }

        [Fact]
        public void ReturnsNullWhenIsNullInBuildingString()
        {
            string value = null;

            var result = value.Build("name", "age");
            
            result.ShouldBeNull();
        }
        
        [Fact]
        public void ReturnsEmptyWhenIsEmptyInBuildingString()
        {
            string value = String.Empty;

            var result = value.Build("name", "age");
            
            result.ShouldBeEmpty();
        }

        [Fact]
        public void ReturnsBuiltText()
        {
            var text = "valueOne: {0}, valueTwo: {1}";

            var result = text.Build("name", "age");
            
            result.ShouldBe("valueOne: name, valueTwo: age");
        }
    }
}
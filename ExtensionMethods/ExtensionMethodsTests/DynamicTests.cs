﻿using System;
using ExtensionMethods;
using Shouldly;
using Xunit;

namespace ExtensionMethodsTests
{
    public class DynamicHasPropertyTests
    {
        [Fact]
        public void ReturnsFalseWhenDynamicIsNull()
        {
            var result = new Dynamic(null).HasProperty("Name");

            result.ShouldBeFalse();
        }

        [Fact]
        public void ReturnsFalseWhenPropertyNameIsNull()
        {
            var entity = new { Name="John" };
            
            var result = new Dynamic(entity).HasProperty(null);

            result.ShouldBeFalse();
        }
        
        [Fact]
        public void ReturnsFalseWhenPropertyNameIsEmpty()
        {
            var entity = new { Name="John" };
            
            var result = new Dynamic(entity).HasProperty(String.Empty);

            result.ShouldBeFalse();
        }
        
        [Fact]
        public void ReturnsFalseWhenPropertyNameIsWhiteSpace()
        {
            var entity = new { Name="John" };
            
            var result = new Dynamic(entity).HasProperty(" ");

            result.ShouldBeFalse();
        }
        
        [Fact]
        public void ReturnsFalseWhenHasNoProperty()
        {
            var entity = new { Name="John" };
            
            var result = new Dynamic(entity).HasProperty("FirstName");

            result.ShouldBeFalse();
        }
        
        [Fact]
        public void ReturnsTrueWhenHasProperty()
        {
            var entity = new { Name="John" };
            
            var result = new Dynamic(entity).HasProperty("Name");

            result.ShouldBeTrue();
        }
    }
}
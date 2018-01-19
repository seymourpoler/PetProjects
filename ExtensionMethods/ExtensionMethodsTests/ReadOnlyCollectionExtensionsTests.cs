﻿using System.Collections.Generic;
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
        public void ReturnsTrueWhenIsNull()
        {
            IReadOnlyCollection<string> values = null;

            var result = values.IsNullOrEmpty();

            result.ShouldBeTrue();
        }
        
    }
}
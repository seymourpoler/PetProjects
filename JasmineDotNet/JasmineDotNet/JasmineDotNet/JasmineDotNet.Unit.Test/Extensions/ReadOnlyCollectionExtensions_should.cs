using System;
using System.Collections.Generic;
using JasmineDotNet.Extensions;
using Shouldly;
using Xunit;

namespace JasmineDotNet.Unit.Test.Extensions
{
    public class ReadOnlyCollectionExtensions_should
    {
        [Fact]
        public void throw_argument_out_of_range_exception()
        {
            var collection = new List<string>().AsReadOnly();

            Action action = () => { collection.Second(); };

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }
        
        [Fact]
        public void return_second_element()
        {
            const string secondElement = "0";
            var collection = new List<string> {"h", secondElement, "la"}.AsReadOnly();

            var result = collection.Second();

            result.ShouldBe(secondElement);
        }
    }
}
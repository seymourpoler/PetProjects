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
    }
}
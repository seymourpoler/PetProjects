using System;
using Shouldly;
using Xunit;

namespace RedisDotNet.Unit.Test
{
    public class Check_should
    {
        [Fact]
        public void throw_argument_null_exception()
        {
            Action action = () => { Check.IsNull<ArgumentNullException>(null); };

            action.ShouldThrow<ArgumentNullException>();
        }
    }
}
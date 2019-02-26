using System;
using Shouldly;
using Xunit;

namespace JasmineDotNet.Unit.Test
{
    public class CheckShould
    {
        [Fact]
        public void throws_argument_null_exception_when_argument_is_null()
        {
            Action action = () => Check.IsNull<ArgumentNullException>(null);

            action.ShouldThrow<ArgumentNullException>();
        }
        
        [Fact]
        public void throws_argument_null_exception_when_argument_satisfy_the_condition()
        {
            Action action = () => Check.If<ArgumentNullException>(() => String.IsNullOrWhiteSpace(""));

            action.ShouldThrow<ArgumentNullException>();
        }
    }
}
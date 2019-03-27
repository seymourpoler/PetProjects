using System;
using Shouldly;
using Xunit;
using static JasmineDotNet.Functions;

namespace JasmineDotNet.Unit.Test
{
    public class Expect_should
    {
        [Fact]
        public void do_nothing_when_is_expected()
        {
            Expect<string>(null).ToBeNull();
        }
        
        [Fact]
        public void throw_an_expect_exception_when_is_not_null()
        {
            Action action = () =>
            {
                Expect<string>("hello world!").ToBeNull();
            };

            action.ShouldThrow<ExpectException>();
        }
    }
}
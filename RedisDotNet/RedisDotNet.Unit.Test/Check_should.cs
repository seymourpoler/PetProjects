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
        
        [Fact]
        public void do_nothing_when_is_not_null()
        {
            Action action = () => { Check.IsNull<ArgumentNullException>("as"); };

            action.ShouldNotThrow();
        }

        [Fact]
        public void throw_argument_exception_when_collection_is_null()
        {
            Action action = () => { Check.IsNullOrEmpty<string, ArgumentException>(null); };

            action.ShouldThrow<ArgumentException>();
        }
        
        [Fact]
        public void throw_argument_exception_when_collection_is_empty()
        {
            Action action = () => { Check.IsNullOrEmpty<string, ArgumentException>(new string[]{}); };

            action.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void do_nothing_when_collection_has_elements()
        {
            Action action = () => { Check.IsNullOrEmpty<string, ArgumentException>(new []{"je", "os"}); };

            action.ShouldNotThrow();
        }

        [Fact]
        public void throw_argument_exception_when_value_is_null()
        {
            Action action = () => { Check.IsNullOrWhiteSpace<ArgumentException>(null); };

            action.ShouldThrow<ArgumentException>();
        }
        
        [Fact]
        public void throw_argument_exception_when_value_is_string_empty()
        {
            Action action = () => { Check.IsNullOrWhiteSpace<ArgumentException>(String.Empty); };

            action.ShouldThrow<ArgumentException>();
        }
        
        [Fact]
        public void throw_argument_exception_when_value_is_white_space()
        {
            Action action = () => { Check.IsNullOrWhiteSpace<ArgumentException>("  "); };

            action.ShouldThrow<ArgumentException>();
        }
        
        [Fact]
        public void do_nothing_when_has_value()
        {
            Action action = () => { Check.IsNullOrWhiteSpace<ArgumentException>("  than"); };

            action.ShouldNotThrow();
        }

        [Fact]
        public void throw_argument_exception_when_condition_is_true()
        {
            Action action = () => { Check.If<ArgumentException>(() => 2 == 2); };

            action.ShouldThrow<ArgumentException>();
        }
        
        [Fact]
        public void do_nothing_argument_exception_when_condition_is_false()
        {
            Action action = () => { Check.If<ArgumentException>(() => 2 != 2); };

            action.ShouldNotThrow();
        }
    }
}
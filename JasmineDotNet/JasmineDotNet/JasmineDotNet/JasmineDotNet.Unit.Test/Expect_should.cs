﻿using System;
using Shouldly;
using Xunit;

namespace JasmineDotNet.Unit.Test
{
    public class Expect_should
    {
        [Fact]
        public void do_nothing_when_is_expected()
        {
            new Expect<string>(null).ToBeNull();
        }
        
        [Fact]
        public void throw_an_expect_exception_when_is_not_null()
        {
            Action action = () =>
            {
                new Expect<string>("hello world!").ToBeNull();
            };

            action.ShouldThrow<ExpectException>();
        }

        [Fact]
        public void do_nothing_when_is_equals()
        {
            new Expect<bool>(true).ToBe(true);
        }
        
        [Fact]
        public void throw_an_expect_exception_when_is_not_equals()
        {
            Action action = () =>
            {
                new Expect<bool>(true).ToBe(false);
            };

            action.ShouldThrow<ExpectException>();
        }
    }
}
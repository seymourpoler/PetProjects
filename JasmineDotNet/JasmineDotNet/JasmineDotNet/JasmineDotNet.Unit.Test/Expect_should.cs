﻿using System;
using System.Data;
using JasmineDotNet.Expects;
using Shouldly;
using Xunit;

namespace JasmineDotNet.Unit.Test
{
    public class Expect_should
    {
        [Fact]
        public void do_nothing_when_is_null()
        {
            new Expected<string>(value:null).ToBeNull();
        }
        
        [Fact]
        public void throw_an_expect_exception_when_is_not_null()
        {
            Action action = () =>
            {
                new Expected<string>("hello world!").ToBeNull();
            };

            action.ShouldThrow<ExpectException>();
        }
        
        [Fact]
        public void do_nothing_when_is_not_null()
        {
            new Expected<string>("text").Not.ToBeNull();
        }
        
        [Fact]
        public void throw_exception_when_is_not_null()
        {
            Action action = () =>
            {
                new Expected<string>(value:null).Not.ToBeNull();
            };

            action.ShouldThrow<ExpectException>();
        }

        [Fact]
        public void do_nothing_when_is_be()
        {
            new Expected<bool>(true).ToBe(true);
        }
        
        [Fact]
        public void throw_an_expect_exception_when_is_not_be()
        {
            Action action = () =>
            {
                new Expected<bool>(true).ToBe(false);
            };

            action.ShouldThrow<ExpectException>();
        }

        [Fact]
        public void do_nothing_when_is_not_be()
        {
            new Expected<bool>(false).Not.ToBe(true);
        }
        
        [Fact]
        public void throw_exception_when_is_not_be()
        {
            Action action = () =>
            {
                new Expected<bool>(true).Not.ToBe(true);
            };

            action.ShouldThrow<ExpectException>();
        }
        
        [Fact]
        public void do_nothing_when_is_true()
        {
            new Expected<bool>(true).ToBeTrue();
        }
        
        [Fact]
        public void throw_exception_when_is_not_true()
        {
            Action action = () =>
            {
                new Expected<bool>(true).Not.ToBeTrue();
            };

            action.ShouldThrow<ExpectException>();
        }
        
        [Fact]
        public void do_nothing_when_is_not_true()
        {
            new Expected<bool>(false).Not.ToBeTrue();
        }
        
        [Fact]
        public void throw_exception_when_is_false()
        {
            Action action = () =>
            {
                new Expected<bool>(false).ToBeTrue();  
            };

            action.ShouldThrow<ExpectException>();
        }
        
        [Fact]
        public void do_nothing_whe_is_false()
        {
            new Expected<bool>(false).ToBeFalse();
        }
        
        [Fact]
        public void throw_exception_when_is_not_false()
        {
            Action action = () =>
            {
                new Expected<bool>(true).ToBeFalse();
            };

            action.ShouldThrow<ExpectException>();
        }

        [Fact]
        public void do_nothing_whe_is_not_false()
        {
            new Expected<bool>(true).Not.ToBeFalse();
        }
        
        [Fact]
        public void throw_exception_whe_is_not_false()
        {
            Action action = () =>
            {
                new Expected<bool>(false).Not.ToBeFalse();
            };
        }
        
        [Fact]
        public void do_nothing_when_is_not_false()
        {
            new Expected<bool>(false).Not.ToBeTrue();
        }
        
        [Fact]
        public void throw_and_exception_when_is_not_to_be_true()
        {
            Action action = () => { new Expected<bool>(true).Not.ToBeTrue(); };

            action.ShouldThrow<ExpectException>();
        }

        [Fact]
        public void do_nothing_when_there_is_a_thrown_exception()
        {
            new Expected<Exception>(() => { throw new NotSupportedException(); }).ToThrow<Exception>();
        }
        
        [Fact]
        public void throw_exception_when_there_is_no_thrown_exception()
        {
            Action action = () =>
            {
                new Expected<Exception>(() => { }).ToThrow<Exception>();
            };

            action.ShouldThrow<ExpectException>();
        }
    }
}
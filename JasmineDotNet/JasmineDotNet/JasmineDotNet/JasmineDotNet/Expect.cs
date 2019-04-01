using System;
using JasmineDotNet.Extensions;

namespace JasmineDotNet
{
    public class Expect<T>
    {
        private readonly T value;
        
        public Expect(T value)
        {
            this.value = value;
        }

        public void ToBeNull()
        {
            if (value.IsNotNull())
            {
                throw new ExpectException("Expected a null value is expected.");
            }
        }

        public void ToBe(T expectd)
        {
            if (!value.Equals(expectd))
            {
                throw new ExpectException("not equal value is expected.");
            }
        }

        public void ToBeTrue()
        {
            if (!Convert.ToBoolean(value))
            {
                throw new ExpectException("true value is expected.");
            }
        }
    }
}
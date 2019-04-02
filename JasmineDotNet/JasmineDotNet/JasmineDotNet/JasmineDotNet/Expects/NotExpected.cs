using System;
using JasmineDotNet.Extensions;

namespace JasmineDotNet.Expects
{
    public class NotExpected<T>
    {
        readonly T value;
        readonly Action action;

        public NotExpected(T value, Action action)
        {
            this.value = value;
            this.action = action;
        }

        public void ToBeNull()
        {
            if (value.IsNull())
            {
                throw new ExpectException("Expected a null value is expected.");
            }
        }

        public void ToBe(T expectd)
        {
            if (value.Equals(expectd))
            {
                throw new ExpectException("not equal value is expected.");
            }
        }

        public void ToBeTrue()
        {
            if (Convert.ToBoolean(value))
            {
                throw new ExpectException("true value is expected.");
            }
        }

        public void ToBeFalse()
        {
            if (!Convert.ToBoolean(value))
            {
                throw new ExpectException("false value is expected.");
            }
        }

        public void ToThrow<TException>()
        {
            try
            {
                action.Invoke();
            }
            catch (Exception exception)
            {
                if (exception.GetType() == typeof(TException))
                {
                    throw new ExpectException("exception is expected");
                }
            }
        }
        
        public void ToContain(string text)
        {
            if (Convert.ToString(value).Contains(text))
            {
                throw new ExpectException($"contains {text} in {value} is expected");
            }
        }

        public void ToBeGreaterThan(int number)
        {
            if (Convert.ToInt32(value) <= number)
            {
                return;
            }
        }
    }
}
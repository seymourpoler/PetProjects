using System;
using JasmineDotNet.Extensions;

namespace JasmineDotNet.Expects
{
    public class Expected<T>
    {
        readonly T value;
        readonly Action action;

        public Expected(T value)
        {
            this.value = value;
            action = () => { };
        }

        public Expected(Action action)
        {
            this.action = action;
        }

        public NotExpected<T> Not
        {
            get { return new NotExpected<T>(value: value, action: action); }
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

        public void ToBeFalse()
        {
            if (Convert.ToBoolean(value))
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
            catch (Exception e)
            {
                if (e is TException)
                {
                    return;
                }
            }

            throw new ExpectException("exception is expected");
        }

        public void ToContain(string text)
        {
            if (!Convert.ToString(value).Contains(text))
            {
                throw new ExpectException($"contains {text} in {value} is expected");
            }
        }

        public void ToBeGreaterThan(int number)
        {
            if (Convert.ToInt32(value) > number)
            {
                return;
            }
            throw new ExpectException($"{value} is greater than {number} is expected");
        }
    }
}
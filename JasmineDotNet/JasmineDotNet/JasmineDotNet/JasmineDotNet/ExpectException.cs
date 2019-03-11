using System;

namespace JasmineDotNet
{
    public class ExpectException: Exception
    {
        public ExpectException(string message) : base(message)
        {

        }
    }
}
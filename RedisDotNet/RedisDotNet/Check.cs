using System;

namespace RedisDotNet
{
    public static class Check
    {
        public static void IsNull<TException>(object anObject)
        {
            if (anObject is null)
            {
                throw  (Exception)Activator.CreateInstance(typeof(TException));
            }
            
        }
    }
}
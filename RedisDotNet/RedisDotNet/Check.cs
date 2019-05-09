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
        
        public static void IsNullOrEmpty<T, TException>(T[] collection)
        {
            const int noElements = 0;
            if (collection is null || collection.Length == noElements)
            {
                throw  (Exception)Activator.CreateInstance(typeof(TException));
            }
        }

        public static void IsNullOrWhiteSpace<TException>(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw  (Exception)Activator.CreateInstance(typeof(TException));
            }
        }

        public static void If<TException>(Func<bool> condition)
        {
            if (condition.Invoke())
            {
                throw  (Exception)Activator.CreateInstance(typeof(TException));
            }
        }
    }
}
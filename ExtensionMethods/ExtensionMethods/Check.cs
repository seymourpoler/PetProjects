using System;
using ExtensionMethods.Object;

namespace ExtensionMethods
{
    public static class Check
    {
        public static void IsNull<TException>(object anObject)
        {
            if (anObject.IsNull())
            {
                throw  (Exception)Activator.CreateInstance(typeof(TException));
            }
        }
        
        public static void IsNull<TException>(object anObject, string message)
        {
            if (!anObject.IsNull()) return;
            
            var type = typeof(TException);
            var constructor = type.GetConstructor(new[] { typeof(string) });
            var  exception = (Exception)constructor.Invoke(new [] { message });
            throw exception;
        }
        
        public static void If<TException>(Func<bool> condition)
        {
            if (condition.Invoke())
            {
                throw  (Exception)Activator.CreateInstance(typeof(TException));
            }
        }
        
        public static void If<TException>(Func<bool> condition, string message)
        {
            if (!condition.Invoke()) return;
            
            var type = typeof(TException);
            var constructor = type.GetConstructor(new[] { typeof(string) });
            var  exception = (Exception)constructor.Invoke(new [] { message });
            throw exception;
        }
    }
}
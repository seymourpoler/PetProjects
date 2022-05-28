using System;
using ExtensionMethods.Object;

namespace ExtensionMethods
{
    public static class Check
    {
        public static void IsNull<TException>(object anObject)
        {
            if (!anObject.IsNull()) return;
            
            throw  (Exception)Activator.CreateInstance(typeof(TException));
        }
        
        public static void IsNull<TException>(object anObject, string message)
        {
            if (!anObject.IsNull()) return;

            var exception = BuildException<TException>(message);
            throw exception;
        }

        public static void If<TException>(Func<bool> condition)
        {
            if (!condition.Invoke()) return;
            
            throw  (Exception)Activator.CreateInstance(typeof(TException));
        }

        public static void If<TException>(Func<bool> condition, string message)
        {
            if (!condition.Invoke()) return;
            
            var exception = BuildException<TException>(message);
            throw exception;
        }

        private static Exception  BuildException<TException>(string message)
        {
            var type = typeof(TException);
            var constructor = type.GetConstructor(new[] { typeof(string) });
            return (Exception)constructor.Invoke(new[] { message });
        }
    }
}
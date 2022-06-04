using System;
using System.Collections.Generic;
using System.Linq;
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

            throw BuildException<TException>(message);
        }

        public static void If<TException>(Func<bool> condition)
        {
            if (condition is null) 
                throw new ArgumentNullException();
            
            if (!condition.Invoke()) 
                return;
            
            throw  (Exception)Activator.CreateInstance(typeof(TException));
        }

        public static void If<TException>(Func<bool> condition, string message)
        {
            if (!condition.Invoke()) return;

            throw BuildException<TException>(message);
        }

        public static void IsEmpty<TException, T>(IEnumerable<T> values)
        {
            if (values.Any()) return;
            
            throw  (Exception)Activator.CreateInstance(typeof(TException));
        }

        public static void IsEmpty<TException, T>(IEnumerable<T> values, string message)
        {
            if (values.Any()) return;

            throw BuildException<TException>(message);
        }

        private static Exception  BuildException<TException>(string message)
        {
            var type = typeof(TException);
            var constructor = type.GetConstructor(new[] { typeof(string) });
            return (Exception)constructor.Invoke(new[] { message });
        }
    }
}
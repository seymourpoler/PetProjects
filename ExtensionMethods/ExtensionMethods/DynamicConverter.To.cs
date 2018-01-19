using System;

namespace ExtensionMethods
{
    public partial class DynamicConverter
    {
        public static T To<T>(dynamic entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}

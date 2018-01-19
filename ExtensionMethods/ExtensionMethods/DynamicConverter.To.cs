using System;

namespace ExtensionMethods
{
    public partial class DynamicConverter
    {
        public static T To<T>(dynamic entity) where T : class
        {
            if (entity == null)
            {
                return null;
            }
            throw new NotImplementedException();
        }
    }
}

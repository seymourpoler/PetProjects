namespace ExtensionMethods
{
    public static partial class ObjectExtensions
    {
        public static bool IsNull<T>(this T entity)
        {
            return entity == null;
        }

        public static bool IsNotNull<T>(this T entity)
        {
            return entity != null;
        }
    }
}

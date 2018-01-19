namespace ExtensionMethods.Object
{
    public static partial class ObjectExtensions
    {
        public static bool IsNotNull<T>(this T entity)
        {
            return entity != null;
        }
    }
}
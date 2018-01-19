namespace ExtensionMethods.Object
{
    public static partial class ObjectExtensions
    {
        public static bool IsNull<T>(this T entity)
        {
            return entity == null;
        }
    }
}

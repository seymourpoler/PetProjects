namespace JasmineDotNet
{
    public static class ObjectExtensions
    {
        public static bool IsNotNull(this object anObject)
        {
            return anObject != null;
        }
    }
}
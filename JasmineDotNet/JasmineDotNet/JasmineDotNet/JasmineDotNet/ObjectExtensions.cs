namespace JasmineDotNet
{
    public static class ObjectExtensions
    {
        public static bool IsNotNull(this object anObject)
        {
            return anObject != null;
        }
        
        public static bool IsNull(this object anObject)
        {
            return anObject is null;
        }
    }
}
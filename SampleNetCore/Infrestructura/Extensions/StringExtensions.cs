namespace Infrestructura.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string text)
        {
            return text.Length == 0;
        }
    }
}

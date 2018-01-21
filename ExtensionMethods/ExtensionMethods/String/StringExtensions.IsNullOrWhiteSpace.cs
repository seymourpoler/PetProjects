
namespace ExtensionMethods.String
{
    public static partial class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string text)
        {
            return System.String.IsNullOrWhiteSpace(text);
        }
    }
}
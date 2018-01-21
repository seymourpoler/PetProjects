using ExtensionMethods.Object;

namespace ExtensionMethods.String
{
    public static partial class StringExtensions
    {
        public static string Build(this string text, params object[] parameters)
        {
            if (text.IsNullOrWhiteSpace())
            {
                return text;
            }
            return System.String.Format(text, parameters);
        }
    }
}
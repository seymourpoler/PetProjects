namespace ExtensionMethods.String
{
    public static partial class StringExtensions
    {
        public static string Build(this string text, params object[] parameters)
        {
            return System.String.Format(text, parameters);
        }
    }
}
namespace TSharp.Lexer;

public static class StringExtensions
{
    public static bool IsNumber(this string value)
    {
        return value.All(char.IsDigit);
    }
}
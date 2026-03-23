namespace TSharp.Lex;

public static class CharExtensions
{
    public static bool IsNumber(this char value)
    {
        return char.IsNumber(value);
    }
    
    public static bool IsLetter(this char value)
    {
        return char.IsLetter(value);
    }
    public static bool IsWhiteSpace(this char value)
    {
        return char.IsWhiteSpace(value);
    }
}
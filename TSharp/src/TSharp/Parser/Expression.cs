using TSharp.Lexer;

namespace TSharp.Parser;

public abstract record Expression
{
    public record Assign(Token Name, Expression Value) : Expression;
}
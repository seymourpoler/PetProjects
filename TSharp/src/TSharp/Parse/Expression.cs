using TSharp.Lex;

namespace TSharp.Parse;

public abstract record Expression
{
    public record Assign(Token Name, Expression Value) : Expression;
    public record Literal(string Value) : Expression;
}
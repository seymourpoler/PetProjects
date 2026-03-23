using TSharp.Lex;

namespace TSharp.Parse;

public abstract record SyntaxNode
{
    public record Expression(Parse.Expression AnExpression) : SyntaxNode;
    public record Constant(Token Name, Parse.Expression Value) : SyntaxNode;
}
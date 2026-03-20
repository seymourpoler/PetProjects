using TSharp.Lexer;

namespace TSharp.Parser;

public abstract record SyntaxNode
{
    public record Expression(TSharp.Parser.Expression AnExpression) : SyntaxNode;
    public record Constant(Token Name, TSharp.Parser.Expression Value) : SyntaxNode;
}
using LanguageExt;
using TSharp.Lex;

namespace TSharp.Parse;

public class Parser
{
    public Either<Error, List<SyntaxNode>> Parse(ListOfTokens tokens)
    {
        var constant = tokens.GetNextToken();
        if (constant.Type != TokenType.Constant)
            return new Error($"Expected 'const', found '{constant.Lexeme}'");

        var identifier = tokens.GetNextToken();
        if (identifier.Type != TokenType.Identifier)
            return new Error($"Expected identifier, found '{identifier.Lexeme}'");

        var equal = tokens.GetNextToken();
        if (equal.Type != TokenType.Equal)
            return new Error($"Expected '=', found '{equal.Lexeme}'");

        var valueToken = tokens.GetNextToken();
        if (valueToken.Type != TokenType.Number)
            return new Error($"Expected value, found '{valueToken.Lexeme}'");

        var semicolon = tokens.GetNextToken();
        if (semicolon.Type != TokenType.Semicolon)
            return new Error($"Expected ';', found '{semicolon.Lexeme}'");

        return new List<SyntaxNode>
        {
            new SyntaxNode.Constant(identifier, new Expression.Literal(valueToken.Lexeme))
        };
    }
}

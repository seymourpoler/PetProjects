using Xunit;
using TSharp.Lexer;
using TSharp.Parser;
using ParserClass = TSharp.Parser.Parser;

namespace TSharp.Test.Parser;

public class ParserShould
{
    [Fact]
    public void ParsesValidConstDeclaration()
    {
        var listOfTokens = new ListOfTokens();
        listOfTokens.Add(new Token(TokenType.Constant, "const", 1));
        listOfTokens.Add(new Token(TokenType.Identifier, "a", 1));
        listOfTokens.Add(new Token(TokenType.Equal, "=", 1));
        listOfTokens.Add(new Token(TokenType.Number, "4", 1));
        listOfTokens.Add(new Token(TokenType.Semicolon, ";", 1));
        var parser = new ParserClass();

        var result = parser.Parse(listOfTokens);

        Assert.True(result.IsRight);
        SyntaxNode node = null;
        result.IfRight(r => node = r);
        result.IfLeft(e => Assert.Fail($"Unexpected error: {e.Message}"));
        Assert.NotNull(node);
        Assert.IsType<SyntaxNode.Constant>(node);
        var constNode = (SyntaxNode.Constant)node;
        Assert.Equal("a", constNode.Name.Lexeme);
        Assert.Equal("4", ((Expression.Literal)constNode.Value).Value.Lexeme);
    }

    [Theory]
    [InlineData(1, TokenType.Constant, "Expected identifier, found 'a'")]
    [InlineData(2, TokenType.Identifier, "Expected '=', found '='")]
    [InlineData(3, TokenType.Equal, "Expected value, found '4'")]
    [InlineData(4, TokenType.Number, "Expected ';', found '4'")]
    public void ReturnsErrorOnMalformedInput(int wrongIndex, TokenType wrongType, string expectedError)
    {
        // Arrange: tokens for 'const a = 4;'
        var validTokens = new List<Token>{
            new Token(TokenType.Constant, "const", 1),
            new Token(TokenType.Identifier, "a", 1),
            new Token(TokenType.Equal, "=", 1),
            new Token(TokenType.Number, "4", 1),
            new Token(TokenType.Semicolon, ";", 1)
        };
        // Swap only the intended token to a wrong type
        var wrongLexeme = wrongIndex == 4 ? "4" : validTokens[wrongIndex].Lexeme;
        var testTokens = validTokens.Select((t, i) => i==wrongIndex ?
            new Token(wrongType, wrongLexeme, 1) : t).ToList();
        var tokens = new ListOfTokens(testTokens);
        var parser = new ParserClass();

        // Act
        var result = parser.Parse(tokens);

        // Assert
        Assert.True(result.IsLeft);
        Error err = null;
        result.IfLeft(e => err = e);
        result.IfRight(r => Assert.Fail("Unexpected success"));
        Assert.NotNull(err);
        Assert.Contains(expectedError, err.Message);
    }

    [Fact]
    public void ReturnsErrorOnMissingTokens()
    {
        // Arrange: only first token
        var tokens = new ListOfTokens(new List<Token>{
            new Token(TokenType.Constant, "const", 1)
        });
        var parser = new ParserClass();

        // Act
        var result = parser.Parse(tokens);

        // Assert
        Assert.True(result.IsLeft);
        Error err = null;
        result.IfLeft(e => err = e);
        result.IfRight(r => Assert.Fail("Unexpected success"));
        Assert.NotNull(err);
        Assert.Contains("Expected identifier", err.Message);
    }
}

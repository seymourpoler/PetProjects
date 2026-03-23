using Shouldly;
using Xunit;
using TSharp.Lexer;
using TSharp.Parser;

namespace TSharp.Test.Parser;

public class ParserShould
{
    private readonly TSharp.Parser.Parser parser = new TSharp.Parser.Parser();
    
    [Fact]
    public void ParsesValidConstDeclaration()
    {
        var listOfTokens = new ListOfTokens();
        listOfTokens.Add(new Token(TokenType.Constant, "const", 1));
        listOfTokens.Add(new Token(TokenType.Identifier, "a", 1));
        listOfTokens.Add(new Token(TokenType.Equal, "=", 1));
        listOfTokens.Add(new Token(TokenType.Number, "4", 1));
        listOfTokens.Add(new Token(TokenType.Semicolon, ";", 1));

        var result = parser.Parse(listOfTokens);

        result.Match(
            Right: node =>
            {
                node.ShouldBeOfType<SyntaxNode.Constant>();
                ((SyntaxNode.Constant)node).Name.Lexeme.ShouldBe("a");
                var constNode = (SyntaxNode.Constant)node;
                ((Expression.Literal)constNode.Value).Value.ShouldBe("4");
            },
            Left: error => error.ShouldNotBeNull("Should not get here")
        );
    }

    [Theory]
    [InlineData(1, TokenType.Constant, "Expected identifier, found 'a'")]
    [InlineData(2, TokenType.Identifier, "Expected '=', found '='")]
    [InlineData(3, TokenType.Equal, "Expected value, found '4'")]
    [InlineData(4, TokenType.Number, "Expected ';', found '4'")]
    public void ReturnsErrorOnMalformedInput(int wrongIndex, TokenType wrongType, string expectedError)
    {
        var validTokens = new List<Token>{
            new Token(TokenType.Constant, "const", 1),
            new Token(TokenType.Identifier, "a", 1),
            new Token(TokenType.Equal, "=", 1),
            new Token(TokenType.Number, "4", 1),
            new Token(TokenType.Semicolon, ";", 1)
        };
        var wrongLexeme = wrongIndex == 4 ? "4" : validTokens[wrongIndex].Lexeme;
        var testTokens = validTokens.Select((t, i) => i==wrongIndex ?
            new Token(wrongType, wrongLexeme, 1) : t).ToList();
        var tokens = new ListOfTokens(testTokens);

        var result = parser.Parse(tokens);
        
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
        var tokens = new ListOfTokens(new List<Token>{
            new Token(TokenType.Constant, "const", 1)
        });
        
        var result = parser.Parse(tokens);
        
        result.Match(
            Right: node => node.ShouldNotBeNull("Should not get here"),
            Left: error =>
            {
                error.ShouldNotBeNull();
                Assert.Contains("Expected identifier", error.Message);
            }
        );
    }
}

using Shouldly;
using TSharp.Lex;
using TSharp.Parse;
using Xunit;

namespace TSharp.Test.Parser;

public class ParserShould
{
    private readonly Parse.Parser parser = new Parse.Parser();
    
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
            Left: error => error.ShouldBeNull("Should not get here")
        );
    }

    [Fact]
    public void ReturnsErrorWhenConstKeywordIsMissing()
    {
        var tokens = new ListOfTokens(new List<Token> {
            new Token(TokenType.Identifier, "a", 1), // wrong type at index 1
            new Token(TokenType.Equal, "=", 1),
            new Token(TokenType.Number, "4", 1),
            new Token(TokenType.Semicolon, ";", 1)
        });

        var result = parser.Parse(tokens);

        result.Match(
            Right: node => node.ShouldBeNull("Should not get here"),
            Left: err => {
                err.Message.ShouldContain("Expected 'const', found 'a'");
            }
        );
    }
    
    [Fact]
    public void ReturnsErrorWhenIdentifierIsWrongType()
    {
        var tokens = new ListOfTokens(new List<Token> {
            new Token(TokenType.Constant, "const", 1),
            new Token(TokenType.Constant, "const", 1), // wrong type at index 1
            new Token(TokenType.Equal, "=", 1),
            new Token(TokenType.Number, "4", 1),
            new Token(TokenType.Semicolon, ";", 1)
        });

        var result = parser.Parse(tokens);

        result.Match(
            Right: node => node.ShouldBeNull("Should not get here"),
            Left: err => {
                err.Message.ShouldContain("Expected identifier, found 'const'");
            }
        );
    }

    [Fact]
    public void ReturnsErrorWhenAssignmentOperatorIsWrongType()
    {
        var tokens = new ListOfTokens(new List<Token> {
            new Token(TokenType.Constant, "const", 1),
            new Token(TokenType.Identifier, "a", 1),
            new Token(TokenType.Identifier, "a", 1), // wrong type at index 2
            new Token(TokenType.Number, "4", 1),
            new Token(TokenType.Semicolon, ";", 1)
        });

        var result = parser.Parse(tokens);

        result.Match(
            Right: node => node.ShouldBeNull("Should not get here"),
            Left: err => {
                err.ShouldNotBeNull();
                err.Message.ShouldContain("Expected '=', found 'a'");
            }
        );
    }

    [Fact]
    public void ReturnsErrorWhenValueIsWrongType()
    {
        var tokens = new ListOfTokens(new List<Token> {
            new Token(TokenType.Constant, "const", 1),
            new Token(TokenType.Identifier, "a", 1),
            new Token(TokenType.Equal, "=", 1),
            new Token(TokenType.Equal, "=", 1), // wrong type at index 3
            new Token(TokenType.Semicolon, ";", 1)
        });

        var result = parser.Parse(tokens);

        result.Match(
            Right: node => node.ShouldBeNull("Should not get here"),
            Left: err => {
                err.ShouldNotBeNull();
                err.Message.ShouldContain("Expected value, found '='");
            }
        );
    }

    [Fact]
    public void ReturnsErrorWhenSemicolonIsWrongType()
    {
        var tokens = new ListOfTokens(new List<Token> {
            new Token(TokenType.Constant, "const", 1),
            new Token(TokenType.Identifier, "a", 1),
            new Token(TokenType.Equal, "=", 1),
            new Token(TokenType.Number, "4", 1),
            new Token(TokenType.Number, "4", 1) // wrong type at index 4
        });

        var result = parser.Parse(tokens);

        result.Match(
            Right: node => node.ShouldBeNull("Should not get here"),
            Left: err => {
                err.ShouldNotBeNull();
                err.Message.ShouldContain("Expected ';', found '4'");
            }
        );
    }


    [Fact]
    public void ReturnsErrorOnMissingTokens()
    {
        var tokens = new ListOfTokens(new List<Token>{
            new Token(TokenType.Constant, "const", 1)
        });
        
        var result = parser.Parse(tokens);
        
        result.Match(
            Right: node => node.ShouldBeNull("Should not get here"),
            Left: error =>
            {
                error.ShouldNotBeNull();
                Assert.Contains("Expected identifier", error.Message);
            }
        );
    }
}

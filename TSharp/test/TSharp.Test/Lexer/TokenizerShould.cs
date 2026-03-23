using FakeItEasy;
using Shouldly;
using TSharp.Lex;
using Xunit;

namespace TSharp.Test.Lexer;

public class TokenizerShould
{
    private readonly IO io = A.Fake<IO>();
    
    [Fact]
    public void ReturnEmptyListForEmptyInput()
    {
        A.CallTo(() => io.ReadAllText()).Returns(string.Empty);
        var tokenizer = new Tokenizer(new FileReader(io));
        
        var tokens = tokenizer.Tokenize();
        
        var token = tokens.GetNextToken();
        token.Type.ShouldBe(TokenType.EndOfFile);
        token.LineNumber.ShouldBe(1);
    }
    
    [Fact]
    public void ReturnsConstDeclarationCorrectTokens()
    {
        A.CallTo(() => io.ReadAllText()).Returns("const a = 4;");
        var tokenizer = new Tokenizer(new FileReader(io));
        
        var tokens = tokenizer.Tokenize();
        
        var constantToken = tokens.GetNextToken();
        constantToken.Type.ShouldBe(TokenType.Constant);
        constantToken.Lexeme.ShouldBe("const");
        var identifierToken = tokens.GetNextToken();
        identifierToken.Type.ShouldBe(TokenType.Identifier);
        identifierToken.Lexeme.ShouldBe("a");
        var equalToken = tokens.GetNextToken();
        equalToken.Type.ShouldBe(TokenType.Equal);
        equalToken.Lexeme.ShouldBe("=");
        var numberToken = tokens.GetNextToken();
        numberToken.Type.ShouldBe(TokenType.Number);
        numberToken.Lexeme.ShouldBe("4");
        var semicolonToken = tokens.GetNextToken();
        semicolonToken.Type.ShouldBe(TokenType.Semicolon);
        semicolonToken.Lexeme.ShouldBe(";");
        var endOfFileToken = tokens.GetNextToken();
        endOfFileToken.Type.ShouldBe(TokenType.EndOfFile);
    }
}
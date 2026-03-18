using FakeItEasy;
using Shouldly;
using TSharp.Lexer;

namespace TSharp.Test.Lexer;

public class TokenizerShould
{
    private readonly IO io;
    private readonly Tokenizer tokenizer;

    public TokenizerShould()
    {
        io = A.Fake<IO>();
        tokenizer = new Tokenizer(new FileReader(io));
    }

    [Fact]
    public void ReturnEmptyListForEmptyInput()
    {
        A.CallTo(() => io.ReadAllText()).Returns(string.Empty);
        
        var tokens = tokenizer.Tokenize();
        
        tokens.Length().ShouldBe(1);
        tokens.First().Type.ShouldBe(TokenType.EndOfFile);
        tokens.First().LineNumber.ShouldBe(3);
    }
    
    [Fact]
    public void ReturnsConstDeclarationCorrectTokens()
    {
        A.CallTo(() => io.ReadAllText()).Returns("const a = 4;");
        
        var tokens = tokenizer.Tokenize().ToList();
        
        tokens.Count.ShouldBe(6);
        tokens[0].Type.ShouldBe(TokenType.Constant);
        tokens[0].Lexeme.ShouldBe("const");
        tokens[1].Type.ShouldBe(TokenType.Identifier);
        tokens[1].Lexeme.ShouldBe("a");
        tokens[2].Type.ShouldBe(TokenType.Equal);
        tokens[2].Lexeme.ShouldBe("=");
        tokens[3].Type.ShouldBe(TokenType.Number);
        tokens[3].Lexeme.ShouldBe("4");
        tokens[4].Type.ShouldBe(TokenType.Semicolon);
        tokens[4].Lexeme.ShouldBe(";");
        tokens[5].Type.ShouldBe(TokenType.EndOfFile);
    }
}
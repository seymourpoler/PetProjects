using FakeItEasy;
using Shouldly;
using TSharp.Lexer;

namespace TSharp.Test.Lexer;

public class TokenizerShould
{
    private readonly FileReader fileReader;
    private readonly Tokenizer tokenizer;


    public TokenizerShould()
    {
        fileReader = A.Fake<FileReader>();
        tokenizer = new Tokenizer(fileReader);
    }

    [Fact]
    public void Tokenize_ConstDeclaration_ReturnsCorrectTokens()
    {
        const int lineNumber = 1;
        var chars = new Queue<char>("const a = 4;");
        A.CallTo(() => fileReader.IsAtTheEnd()).ReturnsLazily(() => chars.Count == 0);
        A.CallTo(() => fileReader.Next()).ReturnsLazily(() => chars.Count > 0 ? chars.Dequeue().ToString() : "");
        A.CallTo(() => fileReader.Current()).ReturnsLazily(() => chars.Count > 0 ? chars.Peek().ToString() : "");
        A.CallTo(() => fileReader.LineNumber()).Returns(lineNumber);
        
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


    [Fact]
    public void ReturnEmptyListForEmptyInput()
    {
        A.CallTo(() => fileReader.IsAtTheEnd()).Returns(true);
        A.CallTo(() => fileReader.LineNumber()).Returns(3);
        
        var tokens = tokenizer.Tokenize();
        
        tokens.Length().ShouldBe(1);
        tokens.First().Type.ShouldBe(TokenType.EndOfFile);
        tokens.First().Line.ShouldBe(3);
    }
}
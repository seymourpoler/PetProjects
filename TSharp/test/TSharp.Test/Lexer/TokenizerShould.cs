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
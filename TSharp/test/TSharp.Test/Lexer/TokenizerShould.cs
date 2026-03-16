using FakeItEasy;
using Shouldly;

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
        
        var tokens = tokenizer.Tokenize();
        
        tokens.ShouldBeEmpty();
    }
}
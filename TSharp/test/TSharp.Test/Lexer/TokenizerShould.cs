using FakeItEasy;
using Shouldly;

namespace TSharp.Test.Lexer;

public class TokenizerShould
{
    [Fact]
    public void ReturnEmptyListForEmptyInput()
    {
        var fileReader = A.Fake<FileReader>();
        A.CallTo(() => fileReader.IsAtTheEnd()).Returns(true);
        var tokenizer = new Tokenizer(fileReader);
        
        var tokens = tokenizer.Tokenize();
        
        tokens.ShouldBeEmpty();
    }
}
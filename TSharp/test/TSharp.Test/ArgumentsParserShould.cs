using Shouldly;

namespace TSharp.Test;

public class ArgumentsParserShould
{
    [Fact]
    public void ReturnErrorWhenThereAreNotArguments()
    {
        var result = ArgumentsParser.Parse(Array.Empty<string>());
        
        result.Match(
            Right: _ => Assert.Fail("Expected an error, but got a successful result."),
            Left: error => error.ShouldBeOfType<Error>()
        );
    }
    
    [Fact]
    public void ReturnErrorWhenArgumentsAreNull()
    {
        var result = ArgumentsParser.Parse(null);
        
        result.Match(
            Right: _ => Assert.Fail("Expected an error, but got a successful result."),
            Left: error => error.ShouldBeOfType<Error>()
        );
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void ReturnErrorWhenFileArgumentsIsEmpty(string argument)
    {
        var result = ArgumentsParser.Parse([argument]);
        result.Match(
            Right: _ => Assert.Fail("Expected an error, but got a successful result."),
            Left: error => error.ShouldBeOfType<Error>()
        );
    }
    
    [Fact]
    public void ReturnParsedArgument()
    {
        var result = ArgumentsParser.Parse(["file.ts"]);
        result.Match(
            Right: x => x.fileName.ShouldBe("file.ts"),
            Left: _ => Assert.Fail("Expected a success, but got a failed result.")
        );
    }
}
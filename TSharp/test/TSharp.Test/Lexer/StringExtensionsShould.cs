using Shouldly;
using TSharp.Lexer;

namespace TSharp.Test.Lexer;

public class StringExtensionsShould
{
    [Fact]
    public void ReturnTrueIfAllCharactersAreDigits()
    {
        "123".IsNumber().ShouldBeTrue();
    }
    
    [Theory]
    [InlineData("a123")]
    [InlineData("1a23")]
    [InlineData("12a3")]
    [InlineData("123a")]
    [InlineData("1a2b3c")]
    public void ReturnFalseIfAnyCharacterIsNotADigit(string value)
    {
        value.IsNumber().ShouldBeFalse();
    }
}
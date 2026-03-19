using Shouldly;
using TSharp.Lexer;
using Xunit;

namespace TSharp.Test.Lexer;

public class CharExtensionsShould
{
    [Fact]
    public void IsNumber()
    {
        '1'.IsNumber().ShouldBeTrue();
        'a'.IsNumber().ShouldBeFalse();
    }
    
    [Fact]
    public void IsLetter()
    {
        '1'.IsLetter().ShouldBeFalse();
        'a'.IsLetter().ShouldBeTrue();
    }

    [Fact]
    public void IsWhiteSpace()
    {
        ' '.IsWhiteSpace().ShouldBeTrue();
        '1'.IsWhiteSpace().ShouldBeFalse();
        'a'.IsWhiteSpace().ShouldBeFalse();
        '~'.IsWhiteSpace().ShouldBeFalse();
    }
}
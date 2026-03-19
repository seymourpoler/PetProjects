using FakeItEasy;
using Shouldly;
using TSharp.Lexer;
using Xunit;

namespace TSharp.Test.Lexer;

public class FileReaderShould
{
    private readonly IO io = A.Fake<IO>();
    
    [Fact]
    public void BeAtTheEndWhenContentIsEmpty()
    {
        A.CallTo(() => io.ReadAllText()).Returns(string.Empty);
        var fileReader = new FileReader(io);
        
        fileReader.IsAtTheEnd().ShouldBeTrue();
    }

    [Fact]
    public void NotBeAtTheEndWhenContentRemains()
    {
        A.CallTo(() => io.ReadAllText()).Returns("abc");
        var fileReader = new FileReader(io);
        
        fileReader.IsAtTheEnd().ShouldBeFalse();
    }
    
    [Fact]
    public void ReturnTheWholeString()
    {
        A.CallTo(() => io.ReadAllText()).Returns("abc");
        var fileReader = new FileReader(io);
        
        fileReader.GetNextCharacter().ShouldBe('a');
        fileReader.GetCurrentString().ShouldBe("abc");
        fileReader.GetNextCharacter();
        fileReader.IsAtTheEnd().ShouldBeTrue();
    }

    [Fact]
    public void ReturnNextCharacter()
    {
        A.CallTo(() => io.ReadAllText()).Returns("ab");
        var fileReader = new FileReader(io);

        fileReader.GetNextCharacter().ShouldBe('a');
        fileReader.GetNextCharacter().ShouldBe('b');
        fileReader.GetNextCharacter().ShouldBe('\0');
        fileReader.IsAtTheEnd().ShouldBeTrue();
    }

    [Fact]
    public void ReturnCurrentString()
    {
        A.CallTo(() => io.ReadAllText()).Returns("hello world");
        var fileReader = new FileReader(io);
        
        fileReader.GetNextCharacter().ShouldBe('h');
        fileReader.GetCurrentString().ShouldBe("hello");
        fileReader.GetNextCharacter().ShouldBe(' ');
        fileReader.GetNextCharacter().ShouldBe('w');
        fileReader.GetCurrentString().ShouldBe("world");
        fileReader.GetNextCharacter();
        fileReader.IsAtTheEnd().ShouldBeTrue();
    }

    [Fact]
    public void ReturnIdentifierAndNumber()
    {
        A.CallTo(() => io.ReadAllText()).Returns("42 abc");
        var fileReader = new FileReader(io);

        fileReader.GetNextCharacter().ShouldBe('4');
        fileReader.GetCurrentString().ShouldBe("42");
        fileReader.GetNextCharacter().ShouldBe(' ');
        fileReader.GetNextCharacter().ShouldBe('a');
        fileReader.GetCurrentString().ShouldBe("abc");
        fileReader.GetNextCharacter();
        fileReader.IsAtTheEnd().ShouldBeTrue();
    }

    [Fact]
    public void ReturnIdentifier()
    {
        A.CallTo(() => io.ReadAllText()).Returns("abc;");
        var fileReader = new FileReader(io);
        
        fileReader.GetNextCharacter().ShouldBe('a');
        fileReader.GetCurrentString().ShouldBe("abc");
        fileReader.GetNextCharacter().ShouldBe(';');
        fileReader.GetNextCharacter();
        fileReader.IsAtTheEnd().ShouldBeTrue();
    }
    
    [Fact]
    public void ReturnNumber()
    {
        A.CallTo(() => io.ReadAllText()).Returns("123;");
        var fileReader = new FileReader(io);
        
        fileReader.GetNextCharacter().ShouldBe('1');
        fileReader.GetCurrentString().ShouldBe("123");
        fileReader.GetNextCharacter().ShouldBe(';');
        fileReader.GetNextCharacter();
        fileReader.IsAtTheEnd().ShouldBeTrue();
    }
    
    [Fact]
    public void ReturnNumberOfLinesWithNewLine()
    {
        A.CallTo(() => io.ReadAllText()).Returns("a\nb\nc");
        var fileReader = new FileReader(io);

        fileReader.GetCurrentLineNumber().ShouldBe(1);
        fileReader.GetNextCharacter().ShouldBe('a');
        fileReader.GetNextCharacter().ShouldBe('\n');
        fileReader.GetCurrentLineNumber().ShouldBe(2);
        fileReader.GetNextCharacter().ShouldBe('b');
        fileReader.GetNextCharacter().ShouldBe('\n');
        fileReader.GetCurrentLineNumber().ShouldBe(3);
        fileReader.GetNextCharacter().ShouldBe('c');
        fileReader.GetNextCharacter();
        fileReader.IsAtTheEnd().ShouldBeTrue();
    }

    [Fact]
    public void ReturnNumberOfLinesWithWindowsNewLine()
    {
        A.CallTo(() => io.ReadAllText()).Returns("a\r\nb\r\nc");
        var fileReader = new FileReader(io);

        fileReader.GetCurrentLineNumber().ShouldBe(1);
        fileReader.GetNextCharacter().ShouldBe('a');
        fileReader.GetNextCharacter().ShouldBe('\n'); // now line 2
        fileReader.GetCurrentLineNumber().ShouldBe(2);
        fileReader.GetNextCharacter().ShouldBe('b');
        fileReader.GetNextCharacter().ShouldBe('\n'); // now line 3
        fileReader.GetCurrentLineNumber().ShouldBe(3);
        fileReader.GetNextCharacter().ShouldBe('c');
        fileReader.GetNextCharacter();
        fileReader.IsAtTheEnd().ShouldBeTrue();
    }
}

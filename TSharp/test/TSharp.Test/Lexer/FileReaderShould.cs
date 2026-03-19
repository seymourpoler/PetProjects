using FakeItEasy;
using Shouldly;
using TSharp.Lexer;
using Xunit;

namespace TSharp.Test.Lexer;

public class FileReaderShould
{
    private readonly IO io;
    private FileReader fileReader;
    
    public FileReaderShould()
    {
         io = A.Fake<IO>();
         fileReader = new FileReader(io);
    }
    [Fact]
    public void IsAtTheEnd_ReturnsTrue_WhenContentIsEmpty()
    {
        A.CallTo(() => io.ReadAllText()).Returns(string.Empty);
        
        fileReader.IsAtTheEnd().ShouldBeTrue();
    }

    [Fact]
    public void IsAtTheEnd_ReturnsFalse_WhenContentRemaining()
    {
        A.CallTo(() => io.ReadAllText()).Returns("abc");
        fileReader = new FileReader(io);
        
        fileReader.IsAtTheEnd().ShouldBeFalse();
    }

    [Fact]
    public void FindNextCharacter_AdvancesAndReturnsChars()
    {
        A.CallTo(() => io.ReadAllText()).Returns("ab");
        fileReader = new FileReader(io);

        fileReader.FindNextCharacter().ShouldBe('a');
        fileReader.FindNextCharacter().ShouldBe('b');
        fileReader.FindNextCharacter().ShouldBe('\0');
        fileReader.IsAtTheEnd().ShouldBeTrue();
    }

    [Fact]
    public void GetCurrentString_ExtractsWord_AndAdvancesPosition()
    {
        A.CallTo(() => io.ReadAllText()).Returns("hello world");
        fileReader = new FileReader(io);

        fileReader.GetCurrentString().ShouldBe("hello");
        fileReader.FindNextCharacter().ShouldBe(' ');
        fileReader.GetCurrentString().ShouldBe("world");
        fileReader.IsAtTheEnd().ShouldBeTrue();
    }

    [Fact]
    public void GetCurrentString_ExtractsNumber_AndAdvancesPosition()
    {
        A.CallTo(() => io.ReadAllText()).Returns("42 abc");
        fileReader = new FileReader(io);

        fileReader.GetCurrentString().ShouldBe("42");
        fileReader.FindNextCharacter().ShouldBe(' ');
        fileReader.GetCurrentString().ShouldBe("abc");
        fileReader.IsAtTheEnd().ShouldBeTrue();
    }

    [Fact]
    public void ReturnIdentifier()
    {
        A.CallTo(() => io.ReadAllText()).Returns("abc;");
        fileReader = new FileReader(io);
        
        fileReader.GetCurrentString().ShouldBe("abc");
        fileReader.FindNextCharacter().ShouldBe(';');
        fileReader.IsAtTheEnd().ShouldBeTrue();
    }
    
    [Fact]
    public void ReturnNumber()
    {
        A.CallTo(() => io.ReadAllText()).Returns("123;");
        fileReader = new FileReader(io);
        
        fileReader.GetCurrentString().ShouldBe("123");
        fileReader.FindNextCharacter().ShouldBe(';');
        fileReader.IsAtTheEnd().ShouldBeTrue();
    }
    
    [Fact]
    public void GetCurrentLineNumber_IncrementsOnNewLine()
    {
        A.CallTo(() => io.ReadAllText()).Returns("a\nb\nc");
        fileReader = new FileReader(io);

        fileReader.GetCurrentLineNumber().ShouldBe(1);
        fileReader.FindNextCharacter().ShouldBe('a');
        fileReader.FindNextCharacter().ShouldBe('\n');
        fileReader.GetCurrentLineNumber().ShouldBe(2);
        fileReader.FindNextCharacter().ShouldBe('b');
        fileReader.FindNextCharacter().ShouldBe('\n');
        fileReader.GetCurrentLineNumber().ShouldBe(3);
        fileReader.FindNextCharacter().ShouldBe('c');
        fileReader.IsAtTheEnd().ShouldBeTrue();
    }

    [Fact]
    public void GetCurrentLineNumber_WindowsNewlines()
    {
        A.CallTo(() => io.ReadAllText()).Returns("a\r\nb\r\nc");
        fileReader = new FileReader(io);

        fileReader.GetCurrentLineNumber().ShouldBe(1);
        fileReader.FindNextCharacter().ShouldBe('a');
        fileReader.FindNextCharacter().ShouldBe('\n'); // now line 2
        fileReader.GetCurrentLineNumber().ShouldBe(2);
        fileReader.FindNextCharacter().ShouldBe('b');
        fileReader.FindNextCharacter().ShouldBe('\n'); // now line 3
        fileReader.GetCurrentLineNumber().ShouldBe(3);
        fileReader.FindNextCharacter().ShouldBe('c');
        fileReader.IsAtTheEnd().ShouldBeTrue();
    }
}

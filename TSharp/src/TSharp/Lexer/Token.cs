namespace TSharp.Lexer;

public record Token
{
    public  string Lexeme { get; init; }
    public  TokenType Type { get; init; }
    public  int LineNumber { get; init; }
    
    public Token(TokenType Type, string Lexeme, int LineNumber)
    {
        this.Type = Type;
        this.Lexeme = Lexeme;
        this.LineNumber = LineNumber;
    }
    
    public Token(TokenType tokenType, char character, int lineNumber)
    : this(tokenType, character.ToString(), lineNumber)
    {}
}
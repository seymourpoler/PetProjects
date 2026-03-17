namespace TSharp.Lexer;

public record Token (TokenType Type, string Lexeme, int Line);
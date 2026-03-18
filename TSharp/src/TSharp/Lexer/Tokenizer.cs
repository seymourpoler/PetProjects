namespace TSharp.Lexer;

public class Tokenizer(FileReader fileReader)
{
        public List<Token> Tokenize()
        {
            var tokens = new List<Token>();
            
        while (!fileReader.IsAtTheEnd())
        {
            var ch = fileReader.Next();
            if (char.IsWhiteSpace(ch[0]))
                continue;
            // Keyword or identifier
            if (char.IsLetter(ch[0]))
            {
                var start = ch[0];
                var lexeme = start.ToString();
                while (!fileReader.IsAtTheEnd() && char.IsLetterOrDigit(fileReader.Current()[0]))
                {
                    lexeme += fileReader.Next();
                }
                // Check for keyword const
                if (lexeme == "const")
                    tokens.Add(new Token(TokenType.Constant, lexeme, fileReader.LineNumber()));
                else
                    tokens.Add(new Token(TokenType.Identifier, lexeme, fileReader.LineNumber()));
                continue;
            }
            // Number
            if (char.IsDigit(ch[0]))
            {
                var lexeme = ch[0].ToString();
                while (!fileReader.IsAtTheEnd() && char.IsDigit(fileReader.Current()[0]))
                {
                    lexeme += fileReader.Next();
                }
                tokens.Add(new Token(TokenType.Number, lexeme, fileReader.LineNumber()));
                continue;
            }
            // Symbols
            switch (ch)
            {
                case "=":
                    tokens.Add(new Token(TokenType.Equal, ch, fileReader.LineNumber()));
                    break;
                case ";":
                    tokens.Add(new Token(TokenType.Semicolon, ch, fileReader.LineNumber()));
                    break;
                default:
                    // Ignore unknown for now
                    break;
            }
        }
        tokens.Add(new Token(TokenType.EndOfFile, string.Empty, fileReader.LineNumber()));

                    
                    return tokens;
                }
        }
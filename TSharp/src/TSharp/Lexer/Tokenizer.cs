namespace TSharp.Lexer;

public class Tokenizer(FileReader fileReader)
{
        public List<Token> Tokenize()
        {
            var tokens = new List<Token>();
            
            while (!fileReader.IsAtTheEnd())
            {
                var currentCharacter = fileReader.FindNextCharacter();
                if (currentCharacter.IsWhiteSpace())
                    continue;
                
                if (currentCharacter.IsNumber())
                {
                    var currentNumber = fileReader.GetCurrentString();
                    tokens.Add(new Token(TokenType.Number, currentNumber, fileReader.GetCurrentLineNumber()));
                    continue;
                }
                
                if (currentCharacter.IsLetter())
                {
                    var currentWord = fileReader.GetCurrentString();
                    if (currentWord == "const")
                        tokens.Add(new Token(TokenType.Constant, currentWord, fileReader.GetCurrentLineNumber()));
                    else
                        tokens.Add(new Token(TokenType.Identifier, currentWord, fileReader.GetCurrentLineNumber()));
                    continue;
                }
               
                switch (currentCharacter)
                {
                    case '=':
                        tokens.Add(new Token(TokenType.Equal, currentCharacter, fileReader.GetCurrentLineNumber()));
                        break;
                    case ';':
                        tokens.Add(new Token(TokenType.Semicolon, currentCharacter, fileReader.GetCurrentLineNumber()));
                        break;
                    default:
                        // Ignore unknown for now
                        break;
                }
            }
            tokens.Add(new Token(TokenType.EndOfFile, string.Empty, fileReader.GetCurrentLineNumber()));

                        
            return tokens;
        }
}
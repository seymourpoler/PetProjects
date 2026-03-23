namespace TSharp.Lex;

public class Tokenizer(FileReader fileReader)
{
        public ListOfTokens Tokenize()
        {
            var listOfTokens = new ListOfTokens();
            
            while (!fileReader.IsAtTheEnd())
            {
                var currentCharacter = fileReader.GetNextCharacter();
                if (currentCharacter.IsWhiteSpace())
                    continue;
                
                if (currentCharacter.IsNumber())
                {
                    var currentNumber = fileReader.GetCurrentString();
                    listOfTokens.Add(new Token(TokenType.Number, currentNumber, fileReader.GetCurrentLineNumber()));
                    continue;
                }
                
                if (currentCharacter.IsLetter())
                {
                    var currentWord = fileReader.GetCurrentString();
                    if (currentWord == "const")
                    {
                        listOfTokens.Add(new Token(TokenType.Constant, currentWord, fileReader.GetCurrentLineNumber()));
                    }
                    else
                    {
                        listOfTokens.Add(new Token(TokenType.Identifier, currentWord, fileReader.GetCurrentLineNumber()));
                    }
                    continue;
                }
               
                switch (currentCharacter)
                {
                    case '=':
                        listOfTokens.Add(new Token(TokenType.Equal, currentCharacter, fileReader.GetCurrentLineNumber()));
                        break;
                    case ';':
                        listOfTokens.Add(new Token(TokenType.Semicolon, currentCharacter, fileReader.GetCurrentLineNumber()));
                        break;
                    default:
                        // Ignore unknown for now
                        break;
                }
            }
            listOfTokens.Add(new Token(TokenType.EndOfFile, string.Empty, fileReader.GetCurrentLineNumber()));

                        
            return listOfTokens;
        }
}
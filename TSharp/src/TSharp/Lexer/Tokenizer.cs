namespace TSharp;

public class Tokenizer(FileReader fileReader)
{
        public IEnumerable<Token> Tokenize()
        {
            var tokens = new List<Token>();
            
            while (!fileReader.IsAtTheEnd())
            {
                
            }
            tokens.Add(new Token(TokenType.EndOfFile, string.Empty, fileReader.LineNumber()));
            
            return tokens;
        }
}
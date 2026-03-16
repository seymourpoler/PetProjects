namespace TSharp;

public class Tokenizer(FileReader fileReader)
{
        public IEnumerable<Token> Tokenize()
        {
            var tokens = new List<Token>();
            while (!fileReader.IsAtTheEnd())
            {
                
            }
            return tokens;
            // if (string.IsNullOrWhiteSpace(input))
            // {
            //     return Enumerable.Empty<Token>();
            // }
            //
            // var tokens = new List<Token>();
            // var currentToken = new StringBuilder();
            // bool inString = false;
            //
            // for (int i = 0; i < input.Length; i++)
            // {
            //     char c = input[i];
            //
            //     if (char.IsWhiteSpace(c) && !inString)
            //     {
            //         if (currentToken.Length > 0)
            //         {
            //             tokens.Add(new Token(currentToken.ToString()));
            //             currentToken.Clear();
            //         }
            //     }
            //     else if (c == '"')
            //     {
            //         inString = !inString;
            //         currentToken.Append(c);
            //     }
            //     else
            //     {
            //         currentToken.Append(c);
            //     }
            // }
            //
            // if (currentToken.Length > 0)
            // {
            //     tokens.Add(new Token(currentToken.ToString()));
            // }
            //
            // return tokens;
        }
}
using TSharp.Lexer;

namespace TSharp.Parser;

public class Parser
{
    public List<SyntaxNode> Parse(ListOfTokens tokens)
    {
        while (!tokens.IsAtEnd())
        {
            var token = tokens.GetNextToken();
            throw new NotImplementedException();
        }
        
        throw new NotImplementedException();
    }
}
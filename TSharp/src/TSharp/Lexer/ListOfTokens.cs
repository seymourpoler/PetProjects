namespace TSharp.Lexer;

public class ListOfTokens
{
    private int position = -1;
    private List<Token> tokens = new List<Token>();
    
    public void Add(Token token)
    {
        tokens.Add(token);
    }

    public bool IsAtEnd()
    {
        return position >= tokens.Count - 1;
    }
    
    public Token GetNextToken()
    {
        position++;
        return tokens[position];
    }

    public Token GetPreviousToken()
    {
        return  tokens[position - 1];
    }
}
namespace TSharp.Lexer;

public class FileReader
{
    private int position = 0;
    private int lineNumber = 1;
   private readonly string content;

   public FileReader(IO io)
   {
      content = io.ReadAllText();
   }

    public virtual bool IsAtTheEnd()
    {
        return position >= content.Length;
    }
       
    public virtual char FindNextCharacter()
    {
        if (IsAtTheEnd())
        {
            return '\0';
        }
        var currentCharacter = content[position++];
        if (currentCharacter == '\r' && position < content.Length && content[position] == '\n')
        {
            position++;
            currentCharacter = '\n';
        }
        if (currentCharacter == '\n')
        {
            lineNumber++;
        }
        return currentCharacter;
    }
       
    public virtual string GetCurrentString()
    {
        if (IsAtTheEnd())
        {
            return string.Empty;
        }
        
        if (content[position].IsLetter())
        {
            return GetCurrentWord();
        }
        if (content[position].IsNumber())
        {
            return GetCurrentNumber();
        }
        return content[position].ToString();
    }

    private string GetCurrentNumber()
    {
        var start = position;
        while (start < content.Length && content[start].IsNumber())
        {
            start++;
        }
        var number = content.Substring(position, start - position);
        position = start;
        return number;
    }

    private string GetCurrentWord()
    {
        var start = position;
        while (start < content.Length && content[start].IsLetter())
        {
            start++;
        }
        var word = content.Substring(position, start - position);
        position = start;
            
        return word;
    }

    public virtual int GetCurrentLineNumber()
    {
        return lineNumber;
    }
}
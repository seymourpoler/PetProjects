namespace TSharp.Lex;

public class FileReader
{
    private int position = -1;
    private int lineNumber = 1;
    private readonly string content;

    public FileReader(IO io)
    {
        content = io.ReadAllText();
    }

    public virtual bool IsAtTheEnd()
    {
        return string.IsNullOrWhiteSpace(content) || content.Length <= position;
    }
       
    public virtual char GetNextCharacter()
    {
        position++;
        if (IsAtTheEnd())
        {
            return '\0';
        }
        var currentCharacter = content[position];
        if (currentCharacter == '\r' && position < content.Length && content[position+1] == '\n')
        {
            currentCharacter = '\n';
            position++;
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
        var start = position;
        if (content[start].IsLetter())
        {
            return GetCurrentWord();
        }
        if (content[start].IsNumber())
        {
            return GetCurrentNumber();
        }
        position++;
        return content[start].ToString();
    }

    private string GetCurrentNumber()
    {
        var end = position;
        while (end < content.Length && content[end].IsNumber())
        {
            end++;
        }
        var number = content.Substring(position, end - position);
        position = end-1;
        return number;
    }

    private string GetCurrentWord()
    {
        var end = position;
        while (end < content.Length && content[end].IsLetter())
        {
            end++;
        }
        var word = content.Substring(position, end - position);
        position = end-1;
        return word;
    }

    public virtual int GetCurrentLineNumber()
    {
        return lineNumber;
    }
}
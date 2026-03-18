namespace TSharp.Lexer;

public class IO
{
    private readonly string filePath;

    public IO(string filePath)
    {
        this.filePath = filePath;
    }

    public virtual string ReadAllText()
    {
        return File.ReadAllText(filePath);
    }
}
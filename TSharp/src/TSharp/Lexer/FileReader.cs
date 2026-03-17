namespace TSharp.Lexer;

public class FileReader
{
   private readonly string filePath;

   public FileReader(string filePath)
   {
      this.filePath = filePath;
   }

   public virtual bool IsAtTheEnd()
   {
      throw new NotImplementedException();
   }

   public virtual string Next()
   {
      throw new NotImplementedException();
   }
   
   public virtual string Current()
   {
      throw new NotImplementedException();
   }

   public virtual int LineNumber()
   {
      throw new NotImplementedException();
   }
}
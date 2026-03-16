namespace TSharp;

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
   
   public virtual char Read()
   {
      throw new NotImplementedException();
   }

   public virtual int LineNumber()
   {
      throw new NotImplementedException();
   }
}
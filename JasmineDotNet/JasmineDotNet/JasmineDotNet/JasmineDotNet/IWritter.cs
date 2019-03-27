namespace JasmineDotNet
{
    public interface IWritter
    {
        void WriteSuite(string text);
        void WriteSucessTest(string text);
        void WriteFailTest(string text);
    }
}
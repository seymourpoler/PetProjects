namespace JasmineDotNet
{
    public interface IWritter
    {
        void WriteSuite(string text, int leftSeparation=0);
        void WriteSucessTest(string text, int leftSeparation=0);
        void WriteIgnored(string text, int leftSeparation=0);
        void WriteFailTest(string text, string errorMessage, int leftSeparation=0);
        void WriteNumberOfTest(int success, int ignored, int fail);
    }
}
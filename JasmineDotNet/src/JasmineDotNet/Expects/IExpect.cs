namespace JasmineDotNet.Expects
{
    public interface IExpect
    {
        void ToBeNull();
        void ToBe<T>(T expected);
        void ToBeTrue();
        void ToBeFalse();
        void ToThrow<T>();
        void ToContain(string value);
        void ToBeGreaterThan(int number);
        void ToBeLessThan(int number);
    }
}
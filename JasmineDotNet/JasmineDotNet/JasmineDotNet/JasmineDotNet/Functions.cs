namespace JasmineDotNet
{
    public static class Functions
    {
        public static Expect<T> Expect<T>(T value)
        {
            return new Expect<T>(value);
        }
    }
}
namespace Monad.Optinal
{
    public static class OptionalExtensions
    {
        public static IOptional<T> ToOptional<T>(this T value) where T : class
        {
            if(value == default(T))
            {
                return new None<T>();
            }
            return new Some<T>(value);
        }
    }
}

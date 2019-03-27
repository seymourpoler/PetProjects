using JasmineDotNet.Extensions;

namespace JasmineDotNet
{
    public class Expect<T>
    {
        private readonly T value;
        
        public Expect(T value)
        {
            this.value = value;
        }

        public void ToBeNull()
        {
            if (value.IsNotNull())
            {
                throw new ExpectException("Expected a null value is expected.");
            }
        }
    }
}
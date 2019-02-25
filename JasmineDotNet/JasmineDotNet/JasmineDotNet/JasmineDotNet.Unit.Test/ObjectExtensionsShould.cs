using Shouldly;
using Xunit;

namespace JasmineDotNet.Unit.Test
{
    public class ObjectExtensionsShould
    {
        [Fact]
        public void return_true_when_is_not_null()
        {
            var user = new User();

            var result = user.IsNotNull();
            
            result.ShouldBeTrue();
        }
        
        class User{}
    }
}
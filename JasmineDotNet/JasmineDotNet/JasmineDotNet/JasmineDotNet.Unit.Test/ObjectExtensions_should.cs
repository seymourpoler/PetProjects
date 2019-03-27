using Shouldly;
using Xunit;

namespace JasmineDotNet.Unit.Test
{
    public class ObjectExtensions_should
    {
        [Fact]
        public void return_true_when_is_not_null()
        {
            var user = new User();

            var result = user.IsNotNull();
            
            result.ShouldBeTrue();
        }

        [Fact]
        public void return_true_when_is_null()
        {
            User user = null;

            var result = user.IsNull();

            result.ShouldBeTrue();
        }
        
        class User{}
    }
}
using System;
using TuduManayer.BussinessLogic.Login.Models;

namespace TuduManayer.BussinessLogic.Login
{
    public interface ILoginValidator
    {
        bool Validate(LoginValidationRequest request);
    }

    public class LoginValidator : ILoginValidator
    {
        public bool Validate(LoginValidationRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

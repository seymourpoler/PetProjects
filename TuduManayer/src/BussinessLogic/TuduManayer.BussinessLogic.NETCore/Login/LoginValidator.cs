using System;
using TuduManayer.BussinessLogic.Login.Models;

namespace TuduManayer.BussinessLogic.Login
{
    public interface ILoginValidator
    {
        bool Validate(Credentials credentials);
    }

    public class LoginValidator : ILoginValidator
    {
        public bool Validate(Credentials credentials)
        {
            throw new NotImplementedException();
        }
    }
}

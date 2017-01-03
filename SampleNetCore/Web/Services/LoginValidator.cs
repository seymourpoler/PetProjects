namespace Web.Services
{
    public interface ILoginValidator
    {
        bool IsValid(LoginValidationRequest request);
    }

    public class LoginValidator : ILoginValidator
    {
        public bool IsValid(LoginValidationRequest request)
        {
            return request.Email == "a@a.es" &&
                request.Password == "1234";
        }
    }

    public class LoginValidationRequest
    {
        public string Email { get; }
        public string Password { get; }

        public LoginValidationRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}

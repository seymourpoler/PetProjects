namespace TuduManayer.BussinessLogic.Login.Models
{
    public class LoginValidationRequest
    {
        public string Email { get; private set; }
        public string PassWord { get; private set; }

        public LoginValidationRequest(string email, string password)
        {
            Email = email;
            PassWord = password;
        }
    }
}

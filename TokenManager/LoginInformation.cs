namespace TokenManager
{
    public class LoginInformation
    {
        public bool Success { get; set; }

        public LoginError ErrorType { get; set; }

        public string ErrorMessage { get; set; }

    }
}
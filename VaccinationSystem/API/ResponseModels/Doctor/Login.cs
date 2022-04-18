namespace API.ResponseModels.Doctor
{
    public class Login
    {
        public string Token { get; set; }
        public ApiUser Doctor { get; set; }
    }
}

namespace API.ResponseModels.Patient
{
    public class Login
    {
        public string Token { get; set; }
        public ApiPatient Patient { get; set; }
    }
}

namespace VaccinationSystem.API.ResponseModels.Admin
{
    public class Login
    {
        public string Token { get; set; }
        public ApiUser Admin { get; set; }
    }
}

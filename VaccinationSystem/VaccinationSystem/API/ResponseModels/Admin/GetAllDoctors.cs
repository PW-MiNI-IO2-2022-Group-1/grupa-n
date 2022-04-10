namespace VaccinationSystem.API.ResponseModels.Admin
{
    public class GetAllDoctors
    {
        public Pagination Pagination { get; set; }
        public ApiUser[] Data { get; set; }
    }
}

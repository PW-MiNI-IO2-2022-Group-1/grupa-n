namespace API.ResponseModels.Admin
{
    public class GetAllDoctors
    {
        public Pagination<VaccinationSystem.Data.Classes.Doctor> Pagination { get; set; }
        public ApiUser[] Data { get; set; }
    }
}

using VaccinationSystem.Data.Classes;

namespace API.ResponseModels.Admin
{
    public class GetAllDoctors
    {
        public Pagination<Doctor> Pagination { get; set; }
        public ApiUser[] Data { get; set; }
    }
}

using VaccinationSystem.Data.Classes;

namespace API.ResponseModels.Admin
{
    public class GetVaccinations
    {
        public Pagination<Visit> Pagination { get; set; }
        public ApiVaccination[] Data { get; set; }
    }
}

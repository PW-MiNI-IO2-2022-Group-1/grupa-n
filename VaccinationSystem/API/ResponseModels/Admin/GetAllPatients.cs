using VaccinationSystem.Data.Classes;

namespace API.ResponseModels.Admin
{
    public class GetAllPatients
    {
        public Pagination<Patient> Pagination { get; set; }
        public ApiPatient[] Data { get; set; }
    }
}

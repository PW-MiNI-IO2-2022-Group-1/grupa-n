namespace API.ResponseModels.Admin
{
    public class GetAllPatients
    {
        public Pagination<VaccinationSystem.Data.Classes.Patient> Pagination { get; set; }
        public ApiPatient[] Data { get; set; }
    }
}

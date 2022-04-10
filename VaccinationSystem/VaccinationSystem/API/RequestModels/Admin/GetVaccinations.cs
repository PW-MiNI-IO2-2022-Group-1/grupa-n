namespace VaccinationSystem.API.RequestModels.Admin
{
    public class GetVaccinations
    {
        public string? Disease { get; set; }
        public string? DoctorId { get; set; }
        public int Page { get; set; }
        public string? PatientId { get; set; }
    }
}

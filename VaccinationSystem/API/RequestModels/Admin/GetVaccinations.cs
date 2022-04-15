namespace API.RequestModels.Admin
{
    public class GetVaccinations
    {
        public string? Disease { get; set; }
        public int? DoctorId { get; set; }
        public int Page { get; set; }
        public int? PatientId { get; set; }
    }
}

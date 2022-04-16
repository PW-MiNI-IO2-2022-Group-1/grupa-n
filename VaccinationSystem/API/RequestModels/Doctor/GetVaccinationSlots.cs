namespace API.RequestModels.Doctor
{
    public class GetVaccinationSlots
    {
        public DateTime? EndDate { get; set; }
        public string? OnlyReserved { get; set; }
        public int Page { get; set; }
        public DateTime? StartDate { get; set; }
    }
}

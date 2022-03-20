namespace VaccinationSystem.Data
{
    public enum VaccinationStatus
    {
        Planned, Completed, Cancelled
    };

    public class VaccinationStatusDto
    {
        VaccinationStatus VaccinationStatus { get; set; }
    }
}

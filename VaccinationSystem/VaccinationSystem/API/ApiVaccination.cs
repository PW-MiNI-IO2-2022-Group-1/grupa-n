namespace VaccinationSystem.API
{
    public class ApiVaccination
    {
        public int Id { get; set; }
        public ApiVaccine Vaccine { get; set; }
        public ApiVaccinationSlot VaccinationSlot { get; set; }
        public string Status { get; set; }
        public ApiPatient Patient { get; set; }
        public ApiUser Doctor { get; set; }
    }
}

using VaccinationSystem.Data.Classes;

namespace VaccinationSystem.IRepositories
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        Task<bool> ReserveVisit(int visitId, int vaccineId, int patientId);
        Task<Visit> GetLatestVisit(int patientId);
        Task<List<Visit>> GetAllHistoryVisits(int patientId);
        Task<List<Visit>> GetAllAvailableVisits();
        Task<bool> IsVaccinated(int vaccineId, int patientId);
        Task<bool> CancelVisit(int visitId, int patientId);
        Patient? GetPatientByEmail(string email);
        Task<Patient> RegisterPatient(string firstName, string lastName, string pesel, string email,
            string password, Address address);
    }
}

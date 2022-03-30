using VaccinationSystem.Data.Classes;

namespace VaccinationSystem.IRepositories
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        Task<bool> ReserveVisit(int visitId, int vaccineId, string patientId);
        Task<Visit> GetLatestVisit(string patientId);
        Task<List<Visit>> GetAllHistoryVisits(string patientId);
        Task<List<Visit>> GetAllAvaibleVisits();
        Task<bool> IsVaccinated(int vaccineId, string patientId);
        Task<bool> CancelVisit(int visitId, string patientId);
    }
}

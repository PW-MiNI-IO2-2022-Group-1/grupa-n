using VaccinationSystem.Data.Classes;

namespace VaccinationSystem.IRepositories
{
    public interface IDoctorRepository : IGenericRepository<Doctor>
    {
        Task<bool> VaccinatePatient(int visitId);
        Task<bool> DeleteVisit(int visitId);
        Task<Visit?> CreateVisit(DateTime date, int doctorId);
        Task<List<Visit>?> GetVisits(int doctorId, string? onlyReserved = null, DateTime? startDate = null, DateTime? endDate = null);
    }
}

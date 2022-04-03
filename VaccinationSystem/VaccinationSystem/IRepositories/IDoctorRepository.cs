using VaccinationSystem.Data.Classes;

namespace VaccinationSystem.IRepositories
{
    public interface IDoctorRepository : IGenericRepository<Doctor>
    {
        Task<bool> VaccinatePatient(int visitId);
        Task<bool> DeleteVisit(int visitId);
        Task<bool> CreateVisit(DateTime date, string DoctorId);
        Task<List<Visit>?> GetVisits(string DoctorId,int page, string? onlyReserved = null, DateTime? startDate = null, DateTime? endDate = null);
    }
}

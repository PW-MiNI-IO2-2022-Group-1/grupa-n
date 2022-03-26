using VaccinationSystem.Data.Classes;

namespace VaccinationSystem.IRepositories
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        Task<bool> RegisterVisit(Visit Visit);

        Task<Visit> GetLatestVisit();
        Task<List<Visit>> GetAllVisits();

        Task<bool> IsVaccinated(Vaccine vaccine);
    }
}

using VaccinationSystem.Data.Classes;

namespace VaccinationSystem.IRepositories
{
    public interface IVisitRepository : IGenericRepository<Visit>
    {
        Task<Visit?> GetVisit(int visitId);
    }
}

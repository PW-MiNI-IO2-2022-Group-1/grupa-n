using VaccinationSystem.Data;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.IRepositories;

namespace VaccinationSystem.Repositories
{
    public class VisitRepository : GenericRepository<Visit>, IVisitRepository
    {
        public VisitRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
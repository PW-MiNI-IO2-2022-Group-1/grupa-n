using VaccinationSystem.Data;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.IRepositories;

namespace VaccinationSystem.Repositories
{
    public class BugReportRepository : GenericRepository<BugReport>, IBugReportRepository
    {
        public BugReportRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

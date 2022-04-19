using Microsoft.EntityFrameworkCore;
using VaccinationSystem.Data;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.IRepositories;

namespace VaccinationSystem.Repositories
{
    public class VisitRepository : GenericRepository<Visit>, IVisitRepository
    {
        public VisitRepository(ApplicationDbContext context) : base(context)
        { }

        public async Task<Visit?> GetVisit(int visitId)
        {
            var entity = context.Visits?.Where(visit => visit.Id == visitId);
            if (entity is null) return null;
            return await entity
                .Include(x => x.Vaccine)
                .Include(x => x.Doctor)
                .SingleAsync();
        }
    }
}
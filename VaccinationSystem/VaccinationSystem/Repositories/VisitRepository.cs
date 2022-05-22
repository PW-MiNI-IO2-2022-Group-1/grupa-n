using Microsoft.EntityFrameworkCore;
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

        public override async Task<Visit?> GetAsync(int id)
        {
            IQueryable<Visit>? entity = context.Visits;
            var query = entity
                .Include(visit => visit.Patient)
                .Include(visit => visit.Doctor)
                .Include(visit => visit.Vaccine)
                .Include(visit => visit.Vaccine.Disease)
                .Include(visit => visit.Patient.Address);
            return await query.FirstOrDefaultAsync(visit => visit.Id == id);
        }
    }
}
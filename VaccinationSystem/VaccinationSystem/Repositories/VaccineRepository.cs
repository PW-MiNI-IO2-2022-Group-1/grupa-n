using Microsoft.EntityFrameworkCore;
using VaccinationSystem.Data;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.IRepositories;

namespace VaccinationSystem.Repositories
{
    public class VaccineRepository : GenericRepository<Vaccine>, IVaccineRepository
    {
        public VaccineRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<List<Vaccine>> GetAllAsync()
        {
            IQueryable<Vaccine>? entity = context.Vaccines;
            return await entity.Include(vaccine => vaccine.Disease).ToListAsync();
        }
    }
}

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
    }
}

using VaccinationSystem.Data;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.IRepositories;

namespace VaccinationSystem.Repositories
{
    public class DiseaseRepository : GenericRepository<Disease>, IDiseaseRepository
    {
        public DiseaseRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

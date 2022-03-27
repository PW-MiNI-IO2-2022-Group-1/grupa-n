using VaccinationSystem.Data;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.IRepositories;

namespace VaccinationSystem.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<List<Visit>> GetAllVisits()
        {
            throw new NotImplementedException();
        }

        public Task<Visit> GetLatestVisit()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsVaccinated(Vaccine vaccine)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterVisit(Visit Visit)
        {
            throw new NotImplementedException();
        }
    }
}

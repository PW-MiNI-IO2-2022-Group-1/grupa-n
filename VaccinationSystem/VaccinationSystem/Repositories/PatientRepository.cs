using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Visit>> GetAllHistoryVisits(string patientId)
        {
            return await context.Visit.Where(visit => visit.PatientId == patientId && visit.Status==VaccinationStatus.Completed).ToListAsync();
        }
        public async Task<List<Visit>> GetAllAvaibleVisits()
        {
            return await context.Visit.Where(visit => visit.PatientId == null && visit.Status == VaccinationStatus.Planned).ToListAsync();
        }
        public async Task<Visit> GetLatestVisit(string patientId)
        {
            return await context.Visit.OrderByDescending(visit => visit.Date).FirstAsync(visit => visit.PatientId == patientId);
        }

        public async Task<bool> IsVaccinated(int vaccineId, string patientId)
        {
            return await context.Visit.AnyAsync(visit => visit.PatientId == patientId && visit.VaccineId == vaccineId && visit.Status == VaccinationStatus.Completed);
        }

        public async Task<bool> ReserveVisit(int visitId,int vaccineId, string patientId)
        {
            var entity = context.Visit.FirstOrDefault(v => v.Id == visitId);
            if (entity == null || entity.PatientId != null) 
                return false;
            entity.PatientId = patientId;
            entity.VaccineId = vaccineId;
            return await context.SaveChangesAsync()>0;
        }
        public async Task<bool> CancelVisit(int visitId, string patientId)
        {
            var entity = context.Visit.FirstOrDefault(v => v.Id == visitId);
            if (entity == null || entity.PatientId != patientId) 
                return false;
            entity.Status = VaccinationStatus.Cancelled;
            return await context.SaveChangesAsync()>0;
        }
    }
}

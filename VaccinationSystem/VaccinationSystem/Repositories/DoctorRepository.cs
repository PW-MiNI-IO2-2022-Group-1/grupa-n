using Microsoft.EntityFrameworkCore;
using VaccinationSystem.Data;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.IRepositories;

namespace VaccinationSystem.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<bool> CreateVisit(DateTime date, string DoctorId)
        {
            Visit visit = new Visit() { DoctorId = DoctorId, Date = date, Status = VaccinationStatus.Planned };
            _ = context.AddAsync(visit);
            return await context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteVisit(int visitId)
        {
            var entity = context.Visit?.FirstOrDefault(visit => visit.Id == visitId);
            if (entity == null || entity.Status != VaccinationStatus.Planned) 
                return false;
            context.Visit?.Remove(entity);
            return await context.SaveChangesAsync() > 0;
        }
        public async Task<List<Visit>?> GetVisits(string DoctorId, int page, string? onlyReserved = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            var entity = context.Visit?.Where(visit => visit.DoctorId == DoctorId && visit.Status == VaccinationStatus.Planned);
            if (entity == null)
                return null;
            if (startDate != null) 
                entity = entity.Where(visit => visit.Date >= startDate);
            if (endDate !=null) 
                entity = entity.Where(visit => visit.Date <= endDate);
            if (onlyReserved == "0") 
                entity = entity.Where(visit => visit.PatientId == null);
            if (onlyReserved == "1") 
                entity = entity.Where(visit => visit.PatientId != null);
            return await entity.ToListAsync();
        }
        public async Task<bool> VaccinatePatient(int visitId)
        {
            var entity = context.Visit?.FirstOrDefault(visit => visit.Id == visitId);
            if (entity == null) 
                return false;
            entity.Status = VaccinationStatus.Completed;
            return await context.SaveChangesAsync() > 0;
        }
    }
}

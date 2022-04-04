using Microsoft.EntityFrameworkCore;
using VaccinationSystem.Data;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.IRepositories;

namespace VaccinationSystem.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        private readonly IVisitRepository visitRepository;
        public DoctorRepository(ApplicationDbContext context, IVisitRepository visitRepository) : base(context)
        {
            this.visitRepository = visitRepository;
        }
        public async Task<Visit?> CreateVisit(DateTime date, string DoctorId)
        {
            if ((date - DateTime.Now).Days < 1)
                return null;
            var entity = context.Visits?.Where(visit => visit.DoctorId == DoctorId);
            entity = entity?.Where(visit => date.AddMinutes(15) > visit.Date);
            entity = entity?.Where(visit => date.AddMinutes(-15) < visit.Date);
            if ( entity?.ToList().Count > 0)
            {
                return null;
            }

            Visit visit = new Visit() { DoctorId = DoctorId, Date = date, Status = VaccinationStatus.Planned };

            var newVisit = await visitRepository.AddAsync(visit);
            return newVisit;

        }
        public async Task<bool> DeleteVisit(int visitId)
        {
            var entity = context.Visits?.FirstOrDefault(visit => visit.Id == visitId);
            if (entity == null || entity.Status != VaccinationStatus.Planned) 
                return false;
            var result = await visitRepository.DeleteAsync(visitId);
            return result;

        }
        public async Task<List<Visit>?> GetVisits(string DoctorId, int page, string? onlyReserved = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            var entity = context.Visits?.Where(visit => visit.DoctorId == DoctorId && visit.Status == VaccinationStatus.Planned);
            if (entity == null)
                return null;
            if (startDate != null) 
                entity = entity.Where(visit => visit.Date >= startDate);
            if (endDate != null) 
                entity = entity.Where(visit => visit.Date <= endDate);
            if (onlyReserved == "0") 
                entity = entity.Where(visit => visit.PatientId == null);
            if (onlyReserved == "1") 
                entity = entity.Where(visit => visit.PatientId != null);
            return await entity
                .Include(visit => visit.Patient)
                .Include(visit => visit.Doctor)
                .Include(visit => visit.Vaccine)
                .ToListAsync();
        }
        public async Task<bool> VaccinatePatient(int visitId)
        {
            var entity = context.Visits?.FirstOrDefault(visit => visit.Id == visitId);
            if (entity == null) 
                return false;
            entity.Status = VaccinationStatus.Completed;
            return await context.SaveChangesAsync() > 0;
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VaccinationSystem.Data;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.IRepositories;

namespace VaccinationSystem.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        public PatientRepository(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore) : base(context)
        {
            _userManager = userManager;
            _userStore = userStore;
        }

        public async Task<List<Visit>> GetAllHistoryVisits(int patientId)
        {
            return await context.Visits
                .Where(visit => visit.PatientId == patientId && visit.Status==VaccinationStatus.Completed)
                .Include(visit => visit.Patient)
                .Include(visit => visit.Doctor)
                .Include(visit => visit.Vaccine)
                .ToListAsync();
        }
        public async Task<List<Visit>> GetAllAvailableVisits()
        {
            return await context.Visits
                .Where(visit => visit.PatientId == null && visit.Status == VaccinationStatus.Planned)
                .Include(visit => visit.Patient)
                .Include(visit => visit.Doctor)
                .Include(visit => visit.Vaccine)
                .ToListAsync();
        }
        public async Task<Visit> GetLatestVisit(int patientId)
        {
            return await context.Visits
                .OrderByDescending(visit => visit.Date)
                .Include(visit => visit.Patient)
                .Include(visit => visit.Doctor)
                .Include(visit => visit.Vaccine)
                .FirstAsync(visit => visit.PatientId == patientId);
        }

        public async Task<bool> IsVaccinated(int vaccineId, int patientId)
        {
            return await context.Visits
                .AnyAsync(visit => visit.PatientId == patientId && visit.VaccineId == vaccineId && visit.Status == VaccinationStatus.Completed);
        }

        public async Task<bool> ReserveVisit(int visitId,int vaccineId, int patientId)
        {
            var entity = context.Visits.FirstOrDefault(v => v.Id == visitId);
            if (entity == null || entity.PatientId != null) 
                return false;
            entity.PatientId = patientId;
            entity.VaccineId = vaccineId;
            return await context.SaveChangesAsync()>0;
        }
        public async Task<bool> CancelVisit(int visitId, int patientId)
        {
            var entity = context.Visits.FirstOrDefault(v => v.Id == visitId);
            if (entity == null || entity.PatientId != patientId) 
                return false;
            entity.Status = VaccinationStatus.Cancelled;
            return await context.SaveChangesAsync()>0;
        }

        public Patient? GetPatientByEmail(string email)
        {
            return (Patient?)context.Users.Where(user => user.Email == email)
                .Include("Address")
                .FirstOrDefault();
        }

        public async Task<Patient> RegisterPatient(string firstName, string lastName, string pesel, string email,
            string password, Address address)
        {
            Patient patient = new Patient()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Pesel = pesel,
                Address = address
            };
            await _userStore.SetUserNameAsync(patient, email, CancellationToken.None);
            var result = await _userManager.CreateAsync(patient, password);
            if (!result.Succeeded)
            {
                throw new Exception("Error while creating doctor.");
            }
            await _userManager.AddToRoleAsync(patient, Roles.Doctor.Name);
            return patient;
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VaccinationSystem.Data;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.IRepositories;

namespace VaccinationSystem.Repositories
{
    public class AdministratorRepository : GenericRepository<Administrator>, IAdministratorRepository
    {
        public AdministratorRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<Doctor> CreateDoctor(string firstName, string lastName, string email, string password)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            Doctor doctor = new Doctor()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PasswordHash = hasher.HashPassword(new ApplicationUser(), password),
                EmailConfirmed = false
            };
            var id = context.Add(doctor).Entity.Id;
            var userRole = new IdentityUserRole<string>
            {
                RoleId = Roles.Doctor.Id,
                UserId = id
            };
            await context.UserRoles.AddAsync(userRole);
            context.SaveChanges();
            return doctor;
        }

        public async Task<bool> DeleteDoctor(string doctorId)
        {
            var entity = context.Users.FirstOrDefault(user => user.Id == doctorId);
            if (entity == null)
                return false;
            context.Users.Remove(entity);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePatient(string patientId)
        {
            var entity = context.Users.FirstOrDefault(user => user.Id == patientId);
            if (entity == null)
                return false;
            context.Users.Remove(entity);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<Doctor?> EditDoctor(string doctorId, string firstName, string lastName, string email)
        {
            var entity = context.Users.FirstOrDefault(user => user.Id == doctorId);
            if (entity == null)
                return null;
            entity.FirstName = firstName;
            entity.LastName = lastName;
            entity.Email = email;
            await context.SaveChangesAsync();
            return (Doctor)entity;
        }

        public async Task<Patient?> EditPatient(string patientId, string? firstName = null, string? lastName = null, string? pesel = null, string? email = null, string? phoneNumber = null)
        {
            Patient? entity = (Patient?)context.Users.FirstOrDefault(user => user.Id == patientId);
            if (entity == null)
                return null;
            if (firstName != null) entity.FirstName = firstName;
            if (lastName != null) entity.LastName = lastName;
            if (pesel != null) entity.Pesel = pesel;
            if (email != null) entity.Email = email;
            if (phoneNumber != null) entity.PhoneNumber = phoneNumber;
            await context.SaveChangesAsync();
            return (Patient)entity;
        }

        public async Task<List<Doctor>> GetAllDoctors()
        {
            return await context.Users
                .Join(context.UserRoles, (user => user.Id), (userRole => userRole.UserId), ((user, userRole) => new { user, userRole }))
                .Where(result => result.userRole.RoleId == Roles.Doctor.Id)
                .Select(result => (Doctor)result.user)
                .ToListAsync();
        }

        public async Task<List<Patient>> GetAllPatients()
        {
            return await context.Users
                .Join(context.UserRoles, (user => user.Id), (userRole => userRole.UserId), ((user, userRole) => new { user, userRole }))
                .Where(result => result.userRole.RoleId == Roles.Patient.Id)
                .Select(result => (Patient)result.user)
                .ToListAsync();
        }

        public async Task<List<Visit>> GetAllVisits(string? disease = null, string? doctorId = null, string? patientId = null)
        {
            IQueryable<Visit>? entity = context.Visits;
            if (disease != null) entity = entity?.Where(visit => visit.Vaccine.Disease.Name == disease);
            if (doctorId != null) entity = entity?.Where(visit => visit.DoctorId == doctorId);
            if (patientId != null) entity = entity?.Where(visit => visit.PatientId == patientId);
            return await entity
                .Include(visit => visit.Patient)
                .Include(visit => visit.Doctor)
                .Include(visit => visit.Vaccine)
                .ToListAsync();
        }

        public Doctor? GetDoctor(string doctorId)
        {
            return (Doctor?)context.Users.FirstOrDefault(user => user.Id == doctorId);
        }

        public Patient? GetPatient(string patientId)
        {
            return (Patient?)context.Users.FirstOrDefault(user => user.Id == patientId);
        }

    }
}

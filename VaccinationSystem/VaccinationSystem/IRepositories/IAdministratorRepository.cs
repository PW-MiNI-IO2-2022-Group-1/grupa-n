using VaccinationSystem.Data.Classes;

namespace VaccinationSystem.IRepositories
{
    public interface IAdministratorRepository : IGenericRepository<Administrator>
    {
        Task<List<Patient>> GetAllPatients();
        Patient? GetPatient(string patientId);
        Task<Patient?> EditPatient(string patientId, string? firstName = null, string? lastName = null, string? pesel = null, string? email = null, string? phoneNumber = null);
        Task<bool> DeletePatient(string patientId);
        Task<List<Doctor>> GetAllDoctors();
        Doctor? GetDoctor(string doctorId);
        Task<Doctor> CreateDoctor(string firstName, string lastName, string email, string password);
        Task<Doctor?> EditDoctor(string doctorId, string firstName, string lastName, string email);
        Task<bool> DeleteDoctor(string doctorId);
        Task<List<Visit>> GetAllVisits(string? disease = null, string? doctorId = null, string? patientId = null);

    }
}

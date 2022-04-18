using VaccinationSystem.Data.Classes;

namespace VaccinationSystem.IRepositories
{
    public interface IAdministratorRepository : IGenericRepository<Administrator>
    {
        Task<List<Patient>> GetAllPatients();
        Patient? GetPatient(int patientId);
        Task<Patient?> EditPatient(int patientId, string? firstName = null, string? lastName = null, string? pesel = null, string? email = null, string? phoneNumber = null);
        Task<bool> DeletePatient(int patientId);
        Task<List<Doctor>> GetAllDoctors();
        Doctor? GetDoctor(int doctorId);
        Task<Doctor> CreateDoctor(string firstName, string lastName, string email, string password);
        Task<Doctor?> EditDoctor(int doctorId, string firstName, string lastName, string email);
        Task<bool> DeleteDoctor(int doctorId);
        Task<List<Visit>> GetAllVisits(string? disease = null, int? doctorId = null, int? patientId = null);

    }
}

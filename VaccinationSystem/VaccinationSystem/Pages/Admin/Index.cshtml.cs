using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VaccinationSystem.Data;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.IRepositories;

namespace VaccinationSystem.Pages
{
    [Authorize(Roles = Roles.Admin.Name)]
    public class AdminPanelModel : PageModel
    {
        private readonly ILogger<AdminPanelModel> _logger;
        private readonly IAdministratorRepository _administratorRepository;
        private readonly IVaccineRepository _vaccineRepository;

        public AdminPanelModel(
            ILogger<AdminPanelModel> logger,
            IAdministratorRepository administratorRepository,
            /* do usuniecia jak Visit bedzie dzialac: */
            IVaccineRepository vaccineRepository)
        {
            _logger = logger;
            _administratorRepository = administratorRepository;
            _vaccineRepository = vaccineRepository;
        }

        public IList<Data.Classes.Doctor> Doctors { get; private set; }
        public IList<Data.Classes.Patient> Patients { get; private set; }
        public IList<Visit> Visits { get; private set; }

        public async Task OnGetAsync()
        {
            ViewData["Message"] = $"Welcome {User.Identity?.Name}";
            Doctors = await _administratorRepository.GetAllDoctors();
            Patients = await _administratorRepository.GetAllPatients();
            Visits = await _administratorRepository.GetAllVisits();
            // Vaccine w zwroconych obiektach Visit jest nullem, pomimo
            // tego ze VaccineId ma ustalona wartosc,
            // robie obejscie
            foreach (var visit in Visits)
            {
                visit.Vaccine = await _vaccineRepository.GetAsync((int)visit.VaccineId);
            }
        }
    }
}
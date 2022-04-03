using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.IRepositories;

namespace VaccinationSystem.Pages.PatientPanel
{

    [Authorize(Roles = "Patient")]
    public class PatientPanelModel : PageModel
    {
        private readonly ILogger<PatientPanelModel> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPatientRepository _patientRepository;

        public Patient Patient { get; private set; }
        public IList<Visit> Visits { get; private set; }

        public PatientPanelModel(
            ILogger<PatientPanelModel> logger,
            UserManager<ApplicationUser> userManager,
            IPatientRepository patientRepository)
        {
            _logger = logger;
            _userManager = userManager;
            _patientRepository = patientRepository;
        }

        public async Task OnGetAsync()
        {
            Patient = (Patient) await _userManager.GetUserAsync(User);
            Visits = await _patientRepository.GetAllHistoryVisits(Patient.Id);

            ViewData["Message"] = $"Welcome {Patient.FirstName} {Patient.LastName}";
        }
    }
}

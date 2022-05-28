using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VaccinationSystem.Data;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.IRepositories;

namespace VaccinationSystem.Pages.Patient
{
    [Authorize(Roles = Roles.Patient.Name)]
    public class PatientPanelModel : PageModel
    {
        private readonly ILogger<PatientPanelModel> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPatientRepository _patientRepository;

        public Data.Classes.Patient Patient { get; private set; }
        public IList<Visit> HistoryVisits { get; private set; }
        public IList<Visit> AvailableVisits { get; private set; }
        public IList<Visit> BookedVisits { get; private set; }

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
            Patient = (Data.Classes.Patient) await _userManager.GetUserAsync(User);
            BookedVisits = await _patientRepository.GetAllBookedVisits(Patient.Id);
            AvailableVisits = await _patientRepository.GetAllAvailableVisits();
            HistoryVisits = await _patientRepository.GetAllHistoryVisits(Patient.Id);

            ViewData["Message"] = $"Welcome {Patient.FirstName} {Patient.LastName}";
        }
    }
}

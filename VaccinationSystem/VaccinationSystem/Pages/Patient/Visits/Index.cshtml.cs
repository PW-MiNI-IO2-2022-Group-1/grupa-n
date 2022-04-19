#nullable disable
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VaccinationSystem.Data;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.IRepositories;

namespace VaccinationSystem.Pages.Patient.Visits
{
    [Authorize(Roles = Roles.Patient.Name)]
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPatientRepository _patientRepository;

        public Data.Classes.Patient Patient { get; private set; }
        public IList<Visit> Visits { get; private set; }

        public IndexModel(UserManager<ApplicationUser> userManager, IPatientRepository patientRepository)
        {
            _userManager = userManager;
            _patientRepository = patientRepository;
        }

        public async Task OnGetAsync()
        {
            Patient = (Data.Classes.Patient) await _userManager.GetUserAsync(User);
            Visits = await _patientRepository.GetAllAvailableVisits();

            //ViewData["Message"] = $"Welcome {Patient.FirstName} {Patient.LastName}";
        }
    }
}

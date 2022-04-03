using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VaccinationSystem.Data;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.IRepositories;

namespace VaccinationSystem.Pages.AdminPanel.Patients
{
    [Authorize(Roles = Roles.Admin.Name)]
    public class EditModel : PageModel
    {
        private readonly IAdministratorRepository _administratorRepository;

        public EditModel(IAdministratorRepository administratorRepository)
        {
            _administratorRepository = administratorRepository;
        }

        [BindProperty]
        public Data.Classes.Patient Patient { get; set; }

        public IActionResult OnGet(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient = _administratorRepository.GetPatient(id);

            if (Patient == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var res = await _administratorRepository.EditPatient(Patient.Id, Patient.FirstName, Patient.LastName, Patient.Pesel, Patient.Email, Patient.PhoneNumber);

            if (res == null)
            {
                return NotFound();
            }

            return RedirectToPage("../Index");
        }
    }
}
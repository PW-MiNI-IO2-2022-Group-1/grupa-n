using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.IRepositories;

namespace VaccinationSystem.Pages.AdminPanel.Patients
{
    [Authorize(Roles = "Administrator")]
    public class DeleteModel : PageModel
    {
        private readonly IAdministratorRepository _administratorRepository;

        public DeleteModel(IAdministratorRepository administratorRepository)
        {
            _administratorRepository = administratorRepository;
        }

        [BindProperty]
        public Patient Patient { get; private set; }

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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (!await _administratorRepository.DeletePatient(id))
            {
                return NotFound();
            }

            return RedirectToPage("../Index");
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VaccinationSystem.Data;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.IRepositories;

namespace VaccinationSystem.Pages.AdminPanel.Doctors
{
    [Authorize(Roles = Roles.Admin.Name)]
    public class DeleteModel : PageModel
    {
        private readonly IAdministratorRepository _administratorRepository;

        public DeleteModel(IAdministratorRepository administratorRepository)
        {
            _administratorRepository = administratorRepository;
        }

        [BindProperty]
        public Data.Classes.Doctor Doctor { get; private set; }

        public IActionResult OnGet(int id)
        {

            Doctor = _administratorRepository.GetDoctor(id);

            if (Doctor == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!await _administratorRepository.DeleteDoctor(id))
            {
                return NotFound();
            }

            return RedirectToPage("../Index");
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.IRepositories;

namespace VaccinationSystem.Pages.AdminPanel.Doctors
{
    [Authorize(Roles = "Administrator")]
    public class EditModel : PageModel
    {
        private readonly IAdministratorRepository _administratorRepository;

        public EditModel(IAdministratorRepository administratorRepository)
        {
            _administratorRepository = administratorRepository;
        }

        // trzeba ApplicationUser bo Doctor ma required field LicenceId
        // ktorego tu nie zmieniamy, ale powoduje !ModelState.IsValid
        [BindProperty]
        public ApplicationUser Doctor { get; set; }

        public IActionResult OnGet(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Doctor = _administratorRepository.GetDoctor(id);

            if (Doctor == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
                return Page();
            }

            var res = await _administratorRepository.EditDoctor(Doctor.Id, Doctor.FirstName, Doctor.LastName, Doctor.Email);

            if (res == null)
            {
                return NotFound();
            }

            return RedirectToPage("../Index");
        }
    }
}
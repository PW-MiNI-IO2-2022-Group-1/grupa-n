using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.IRepositories;

namespace VaccinationSystem.Pages.AdminPanel.Doctors
{
    [Authorize(Roles = "Administrator")]
    public class AddModel : PageModel
    {
        private readonly IAdministratorRepository _administratorRepository;

        public AddModel(IAdministratorRepository administratorRepository)
        {
            _administratorRepository = administratorRepository;
        }

        // trzeba ApplicationUser bo Doctor ma required field LicenceId
        // ktorego tu nie zmieniamy, ale powoduje !ModelState.IsValid
        [BindProperty]
        public ApplicationUser Doctor { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [DisplayName("Confirm password")]
        [Compare(nameof(Password))]
        // na razie luzna walidacja, bo nie mamy silnej ustawionej
        public string ConfirmPassword { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                //var errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
                return Page();
            }

            // na razie nie ustawia licenceId
            _ = await _administratorRepository.CreateDoctor(Doctor.FirstName, Doctor.LastName, Doctor.Email, Password);

            return RedirectToPage("../Index");
        }
    }
}
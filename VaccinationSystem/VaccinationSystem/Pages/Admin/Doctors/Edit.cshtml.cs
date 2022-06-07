using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using VaccinationSystem.Data;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.IRepositories;

namespace VaccinationSystem.Pages.AdminPanel.Doctors
{
    [Authorize(Roles = Roles.Admin.Name)]
    public class EditModel : PageModel
    {
        private readonly IAdministratorRepository _administratorRepository;

        public EditModel(IAdministratorRepository administratorRepository)
        {
            _administratorRepository = administratorRepository;
            Input = new InputModel();
        }

        // trzeba ApplicationUser bo Doctor ma required field LicenceId
        // ktorego tu nie zmieniamy, ale powoduje !ModelState.IsValid
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            public int Id { get; set; }
            [Required]
            [Display(Name = "First name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last name")]
            public string LastName { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
        }

        public IActionResult OnGet(int id)
        {
            ApplicationUser doctor = _administratorRepository.GetDoctor(id);
            if (doctor == null)
            {
                return NotFound();
            }
            Input.Id = doctor.Id;
            Input.FirstName = doctor.FirstName;
            Input.LastName = doctor.LastName;
            Input.Email = doctor.Email;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
                return Page();
            }

            var res = await _administratorRepository.EditDoctor(Input.Id, Input.FirstName, Input.LastName, Input.Email);

            if (res == null)
            {
                return NotFound();
            }

            return RedirectToPage("../Index");
        }
    }
}
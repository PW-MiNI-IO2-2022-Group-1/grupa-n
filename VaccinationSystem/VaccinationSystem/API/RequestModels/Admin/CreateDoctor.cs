using System.ComponentModel.DataAnnotations;

namespace VaccinationSystem.API.RequestModels.Admin
{
    public class CreateDoctor
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [StringLength(100, MinimumLength = 6,
            ErrorMessage = "Password must be at least 6 and at max 100 characters long.")]
        public string Password { get; set; }
    }
}

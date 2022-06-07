using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VaccinationSystem.Data.Classes
{
    public class ApplicationUser : IdentityUser<int>
    {
        [Required]
        [DisplayName("First name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last name")]
        public string LastName { get; set; }

        [DisplayName("Full name")]
        public string FullName => $"{FirstName} {LastName}";
    }
}

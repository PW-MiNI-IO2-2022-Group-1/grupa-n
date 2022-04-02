using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VaccinationSystem.Data.Classes
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [DisplayName("First name")]
        public string? FirstName { get; set; }

        [Required]
        [DisplayName("Last name")]
        public string? LastName { get; set; }
    }
}

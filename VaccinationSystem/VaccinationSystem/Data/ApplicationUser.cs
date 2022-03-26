using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace VaccinationSystem.Data
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
    }
    public class Administrator : ApplicationUser { }
    public class Doctor : ApplicationUser
    {
        [Required]
        public int LicenceId { get; set; }
    }
    public class Patient : ApplicationUser
    {
        [Required]
        public string? Pesel { get; set; }
    }
}

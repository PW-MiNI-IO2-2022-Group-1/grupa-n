using Microsoft.AspNetCore.Identity;

namespace VaccinationSystem.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Pesel { get; set; }
    }
}

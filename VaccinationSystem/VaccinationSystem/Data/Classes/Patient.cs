using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace VaccinationSystem.Data.Classes
{
    public class Patient : ApplicationUser
    {
        [Required]
        public string? Pesel { get; set; }
    
        // nie dodaję VaccinationList, bo to brzmi jak głupie dublowanie informacji w dwóch strukturach

    }
}

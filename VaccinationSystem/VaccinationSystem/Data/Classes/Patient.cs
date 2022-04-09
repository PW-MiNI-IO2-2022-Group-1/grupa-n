using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaccinationSystem.Data.Classes
{
    public class Patient : ApplicationUser
    {
        [Required]
        public string? Pesel { get; set; }

        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public Address Address { get; set; }

        // nie dodaję VaccinationList, bo to brzmi jak głupie dublowanie informacji w dwóch strukturach

    }
}

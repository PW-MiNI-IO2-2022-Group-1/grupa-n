using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace VaccinationSystem.Data.Classes
{
    public class Patient : ApplicationUser
    {
        [Required]
        public string? Pesel { get; set; }
    
        // nie dodaję VaccinationList, bo to brzmi jak głupie dublowanie informacji w dwóch strukturach

        void RegisterVisit(Vaccination vaccination)
        {
            throw new NotImplementedException();
        }

        Vaccination GetLatestVisit()
        {
            throw new NotImplementedException();
        }

        bool IsVaccinated(Vaccine vaccine)
        {
            throw new NotImplementedException();
        }
    }
}

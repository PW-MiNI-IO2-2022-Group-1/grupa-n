using Microsoft.AspNetCore.Identity;

namespace VaccinationSystem.Data
{
    public class Patient : ApplicationUser
    {
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

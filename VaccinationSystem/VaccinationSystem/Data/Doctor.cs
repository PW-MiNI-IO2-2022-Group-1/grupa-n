using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaccinationSystem.Data
{
    public class Doctor : ApplicationUser
    {
        [Required]
        public int LicenseID { get; set; }

        Vaccination AddVaccination()
        {
            throw new NotImplementedException();
        }

        void Vaccinate()
        {
            throw new NotImplementedException();
        }
    }
}

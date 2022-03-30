using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaccinationSystem.Data.Classes
{
    public class Doctor : ApplicationUser
    {
        [Required]
        public string LicenceId { get; set; }

        Visit AddVaccination()
        {
            throw new NotImplementedException();
        }

        void Vaccinate()
        {
            throw new NotImplementedException();
        }
    }
}

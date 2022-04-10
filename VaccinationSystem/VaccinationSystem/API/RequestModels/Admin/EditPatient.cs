using System.ComponentModel.DataAnnotations;
using VaccinationSystem.Data.Classes;

namespace VaccinationSystem.API.RequestModels.Admin
{
    public class EditPatient
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public Address Address { get; set; }
    }
}

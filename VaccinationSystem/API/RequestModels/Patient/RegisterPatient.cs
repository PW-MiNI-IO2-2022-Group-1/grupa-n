using System.ComponentModel.DataAnnotations;
using VaccinationSystem.Data.Classes;

namespace API.RequestModels.Patient
{
    public class RegisterPatient
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
        public string Password { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public Address Address { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace VaccinationSystem.API.RequestModels.Admin
{
    public class EditDoctor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}

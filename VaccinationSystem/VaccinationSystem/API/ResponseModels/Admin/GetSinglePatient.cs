using VaccinationSystem.Data.Classes;

namespace VaccinationSystem.API.ResponseModels.Admin
{
    public class GetSinglePatient
    {
        public string Id {get; set; }
        public string FirstName {get; set; }
        public string LastName {get; set; }
        public string Pesel {get; set; }
        public string Email {get; set; }
        public Address Address { get; set; }
    }
}

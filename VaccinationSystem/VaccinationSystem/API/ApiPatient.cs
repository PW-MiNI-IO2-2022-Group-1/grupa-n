using VaccinationSystem.Data.Classes;

namespace VaccinationSystem.API
{
    public class ApiPatient : ApiUser
    {
        public string Pesel { get; set; }
        public Address Address { get; set; }
    }
}

using VaccinationSystem.Data.Classes;

namespace API
{
    public class ApiPatient : ApiUser
    {
        public string Pesel { get; set; }
        public Address Address { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace VaccinationSystem.Data.Classes
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        public string City { get; set; }

        [RegularExpression("^\\d{2}-\\d{3}$")]
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string LocalNumber { get; set; }
    }
}

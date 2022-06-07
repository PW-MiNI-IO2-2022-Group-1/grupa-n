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
        public string? LocalNumber { get; set; }
        public Address() { }
        public Address(string city, string zipCode, string street, string houseNumber, string localNumber = "")
        {
            this.City = city;
            this.ZipCode = zipCode;
            this.Street = street;
            this.HouseNumber = houseNumber;
            this.LocalNumber = localNumber;
        }
    }
}

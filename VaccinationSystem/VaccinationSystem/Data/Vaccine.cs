using System.ComponentModel.DataAnnotations;

namespace VaccinationSystem.Data
{
    public class Vaccine
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public Diseases Disease { get; set; }
        public int RequiredDoses { get; set; }
        [Required]
        public int SerialNo { get; set; }
    }
}

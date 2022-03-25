using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaccinationSystem.Data
{
    public class Vaccine
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string? Name { get; set; }

        [Required]
        public int SerialNo { get; set; }

        [Required]
        public int DeseaseId { get; set; }

        [ForeignKey("DeseaseId")]
        public Disease? Disease { get; set; }

        public int RequiredDoses { get; set; }
    }
}

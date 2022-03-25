using System.ComponentModel.DataAnnotations;

namespace VaccinationSystem.Data
{
    public class Disease
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace VaccinationSystem.Data.Classes
{
    public class Disease
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}

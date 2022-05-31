using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaccinationSystem.Data.Classes
{
    public enum BugReportOrigin
    {
        Generated, Written
    };
    public class BugReport
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public BugReportOrigin Origin { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }
    }
}

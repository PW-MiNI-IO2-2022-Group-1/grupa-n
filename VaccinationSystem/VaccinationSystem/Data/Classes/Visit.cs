using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaccinationSystem.Data.Classes
{
    public enum VaccinationStatus
    {
        Planned, Completed, Cancelled, Expired
    };

    public class Visit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public VaccinationStatus Status { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int? DoctorId { get; set; }  

        [ForeignKey("DoctorId")]
        public Doctor? Doctor { get; set; }

        public int? PatientId { get; set; }

        [ForeignKey("PatientId")]
        public Patient? Patient { get; set; }

        public int? VaccineId { get; set; }

        [ForeignKey("VaccineId")]
        public Vaccine? Vaccine { get; set; }

        // AssingDoctor, AssignPatient, ChangeStatus to odpowiednie settery, więc nie ma po co tworzyć tych metod
    }
}
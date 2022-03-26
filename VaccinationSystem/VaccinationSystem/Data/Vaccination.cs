using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaccinationSystem.Data
{
    public enum VaccinationStatus
    {
        Planned, Completed, Cancelled
    };

    public class Vaccination
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PatientId { get; set; }

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        [Required]
        public string DoctorId { get; set; }  

        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }

        [Required]
        public VaccinationStatus Status { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int VaccineId { get; set; }  

        [ForeignKey("VaccineId")]
        public Vaccine Vaccine { get; set; }

        // AssingDoctor, AssignPatient, ChangeStatus to odpowiednie settery, więc nie ma po co tworzyć tych metod
    }
}
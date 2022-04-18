using System.ComponentModel.DataAnnotations;

namespace API.RequestModels.Doctor
{
    public class VaccinatePatient
    {
        [RegularExpression("COMPLETED|CANCELED", ErrorMessage = "Status must equal either COMPLETED or CANCELED")]
        public string Status { get; set; }
    }
}

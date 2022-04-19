using System.ComponentModel.DataAnnotations;

namespace API.RequestModels.Patient
{
    public class GetVaccines
    {
        // TODO:
        // moga byc rozdzielone przecinkami
        // [RegularExpression("(?-i)Covid-19|Covid-21|Flu|Other")]
        public string Disease { get; set; }
    }
}

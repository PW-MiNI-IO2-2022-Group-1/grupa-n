using VaccinationSystem.Data.Classes;

namespace API.ResponseModels.Doctor
{
    public class GetVaccinationSlots
    {
        public Pagination<Visit> Pagination { get;set; }
        public object[] Data { get; set; }
    }
}

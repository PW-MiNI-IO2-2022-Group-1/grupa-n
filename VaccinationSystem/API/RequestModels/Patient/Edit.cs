namespace API.RequestModels.Patient
{
    public class Edit : Admin.EditPatient
    {
        public string Password { get; set; }
    }
}

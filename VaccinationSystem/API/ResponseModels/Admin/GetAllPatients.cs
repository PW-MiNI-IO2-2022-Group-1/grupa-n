namespace API.ResponseModels.Admin
{
    public class GetAllPatients
    {
        public Pagination Pagination { get; set; }
        public ApiPatient[] Data { get; set; }
    }
}

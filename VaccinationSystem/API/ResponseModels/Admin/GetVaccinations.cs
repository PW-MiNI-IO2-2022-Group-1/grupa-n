namespace API.ResponseModels.Admin
{
    public class GetVaccinations
    {
        public Pagination Pagination { get; set; }
        public ApiVaccination[] Data { get; set; }
    }
}

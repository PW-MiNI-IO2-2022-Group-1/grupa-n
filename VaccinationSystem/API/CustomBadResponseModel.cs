namespace API
{
    public class CustomBadResponseModel
    {
        public bool Success { get; } = false;
        public string Msg { get; set; }

        public CustomBadResponseModel(string msg)
        {
            Msg = msg;
        }
    }
}

namespace API
{
    public class UnauthorizedResponseModel
    {
        public bool Success { get; } = false;
        public string Msg { get; } = "Unauthorized";
    }
}

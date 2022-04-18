using Microsoft.AspNetCore.Mvc;

namespace API
{
    public class ConflictResponse : ObjectResult
    {
        public ConflictResponse(string msg) : base(new CustomBadResponseModel(msg))
        {
            StatusCode = StatusCodes.Status409Conflict;
        }
    }
}

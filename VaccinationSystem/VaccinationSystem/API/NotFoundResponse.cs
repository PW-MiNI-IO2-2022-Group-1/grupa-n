using Microsoft.AspNetCore.Mvc;

namespace VaccinationSystem.API
{
    public class NotFoundResponse : ObjectResult
    {
        public NotFoundResponse(string msg) : base (new CustomBadResponseModel(msg))
        {
            StatusCode = StatusCodes.Status404NotFound;
        }
    }
}

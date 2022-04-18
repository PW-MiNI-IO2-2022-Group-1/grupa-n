using Microsoft.AspNetCore.Mvc;

namespace API
{
    public class UnauthorizedResponse : ObjectResult 
    {
        public UnauthorizedResponse() : base(new UnauthorizedResponseModel())
        {
            StatusCode = StatusCodes.Status401Unauthorized;
        }
    }
}

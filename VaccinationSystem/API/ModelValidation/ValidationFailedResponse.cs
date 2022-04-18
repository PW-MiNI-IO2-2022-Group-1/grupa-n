using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using API;

namespace API.ModelValidation
{
    public class ValidationFailedResponse : ObjectResult
    {
        public ValidationFailedResponse(ModelStateDictionary modelState)
             : base(new ValidationFailedResponseModel(modelState))
        {
            StatusCode = StatusCodes.Status422UnprocessableEntity;
        }

        public ValidationFailedResponse(object[] data)
             : base(new ValidationFailedResponseModel(data))
        {
            StatusCode = StatusCodes.Status422UnprocessableEntity;
        }
    }
}

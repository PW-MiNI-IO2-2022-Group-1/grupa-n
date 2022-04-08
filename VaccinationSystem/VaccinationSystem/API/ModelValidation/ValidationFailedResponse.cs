using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using VaccinationSystem.API;

namespace VaccinationSystem.API.ModelValidation
{
    public class ValidationFailedResponse : ObjectResult
    {
        public ValidationFailedResponse(ModelStateDictionary modelState)
             : base(new ValidationFailedResponseModel(modelState))
        {
            StatusCode = StatusCodes.Status422UnprocessableEntity;
        }
    }
}

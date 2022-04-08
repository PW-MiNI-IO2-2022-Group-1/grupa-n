using Microsoft.AspNetCore.Mvc.Filters;

namespace VaccinationSystem.API.ModelValidation
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new ValidationFailedResponse(context.ModelState);
            }
        }
    }
}

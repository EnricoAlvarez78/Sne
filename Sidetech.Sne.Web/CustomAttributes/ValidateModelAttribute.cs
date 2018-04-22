using Microsoft.AspNetCore.Mvc.Filters;
using Sidetech.Sne.Web.Model.Validation;

namespace Sidetech.Sne.Web.CustomAttributes
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new ValidationFailedResult(context.ModelState);
            }
        }
    }
}

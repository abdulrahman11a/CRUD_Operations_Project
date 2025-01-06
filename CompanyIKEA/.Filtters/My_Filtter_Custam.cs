using Microsoft.AspNetCore.Mvc.Filters;

namespace CompanyIKEAPL.Filtters
{
    public class My_Filtter_Custam : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}

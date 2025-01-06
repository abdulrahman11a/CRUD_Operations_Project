using Microsoft.AspNetCore.Mvc.Filters;

namespace CompanyIKEAPL.Filtters
{
    public class HandelException : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            ViewResult viewResult = new();

            viewResult.ViewName= "Error";
            context.Result= viewResult;
        }
    }
}

using EmployeeManagement.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeManagement.Validators
{
    public class ValidateEmployeeExistance: IActionFilter 
    {
        private readonly IDataAccess _dataAccess;
        public ValidateEmployeeExistance(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            int id = 0;
            if (context.ActionArguments.ContainsKey("id"))
            {
                id = (int)context.ActionArguments["id"];
                if(id == 0)
                {
                    context.Result = new BadRequestResult();
                    return;
                }
            }
            else
            {
                context.Result = new BadRequestObjectResult("Bad id parameter");
                return;
            }
            var employees = _dataAccess.GetEmployees();
            var entity = employees.SingleOrDefault(x => x.id.Equals(id));
            if (entity == null)
            {
                context.Result = new NotFoundResult();
                return;
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}

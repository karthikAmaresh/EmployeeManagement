using EmployeeManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeManagement.Validators
{
    public class ValidateEmployeeExistance: IActionFilter 
    {
        private readonly IEmployeeService _employeeService;

        public ValidateEmployeeExistance(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
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
            var employees = _employeeService.GetEmployees();
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

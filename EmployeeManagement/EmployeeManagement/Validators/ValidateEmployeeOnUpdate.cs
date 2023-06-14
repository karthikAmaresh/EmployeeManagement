using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Windows.Input;
using EmployeeManagement.Commands;
using EmployeeManagement.Services;

namespace EmployeeManagement.Validators
{
    public class ValidateEmployeeOnUpdate : IActionFilter
    {
        private readonly IEmployeeService _employeeService;

        public ValidateEmployeeOnUpdate(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var command = context.ActionArguments.Values.OfType<UpdateEmployeeCommand>().FirstOrDefault();
            
                if (command.id == 0)
                {
                    context.Result = new BadRequestResult();
                    return;
                }            
            var employee = _employeeService.GetEmployee(command.id);
            if (employee == null)
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

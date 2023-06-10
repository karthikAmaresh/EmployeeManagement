using EmployeeManagement.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Windows.Input;
using EmployeeManagement.Commands;

namespace EmployeeManagement.Validators
{
    public class ValidateEmployeeOnUpdate : IActionFilter
    {
        private readonly IDataAccess _dataAccess;
        public ValidateEmployeeOnUpdate(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var command = context.ActionArguments.Values.OfType<UpdateEmployeeCommand>().FirstOrDefault();
            
                if (command.id == 0)
                {
                    context.Result = new BadRequestResult();
                    return;
                }            
            var employees = _dataAccess.GetEmployees();
            var entity = employees.SingleOrDefault(x => x.id.Equals(command.id));
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

using EmployeeManagement.Commands;
using EmployeeManagement.Models;
using EmployeeManagement.Services;
using MediatR;

namespace EmployeeManagement.Handlers
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, Employee>
    {
        private readonly IEmployeeService _employeeService;

        public UpdateEmployeeHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public Task<Employee> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
        {
            return Task.FromResult(_employeeService.UpdateEmployee(command));
        }
    }
}

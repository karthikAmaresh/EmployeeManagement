using EmployeeManagement.Commands;
using EmployeeManagement.Models;
using EmployeeManagement.Services;
using MediatR;

namespace EmployeeManagement.Handlers
{
    public class AddEmployeeHandler : IRequestHandler<AddEmployeeCommand, Employee>
    {
        private readonly IEmployeeService _employeeService;

        public AddEmployeeHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public Task<Employee> Handle(AddEmployeeCommand command, CancellationToken cancellationToken)
        {
            return Task.FromResult(_employeeService.AddEmployee(command));
        }
    }
}

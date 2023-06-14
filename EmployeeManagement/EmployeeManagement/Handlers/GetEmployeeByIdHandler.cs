using EmployeeManagement.Models;
using EmployeeManagement.Queries;
using EmployeeManagement.Services;
using MediatR;

namespace EmployeeManagement.Handlers
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private readonly IEmployeeService _employeeService;

        public GetEmployeeByIdHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public Task<Employee> Handle(GetEmployeeByIdQuery request , CancellationToken cancellationToken)
        {
            return Task.FromResult(_employeeService.GetEmployee(request.EmployeeId));
        }
    }
}

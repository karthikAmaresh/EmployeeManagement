using EmployeeManagement.Models;
using EmployeeManagement.Queries;
using EmployeeManagement.Services;
using MediatR;

namespace EmployeeManagement.Handlers
{
    public class GetEmployeeListHandler : IRequestHandler<GetEmployeeListQuery , List<Employee>>
    {
        private readonly IEmployeeService _employeeService;

        public GetEmployeeListHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public Task<List<Employee>> Handle(GetEmployeeListQuery request , CancellationToken cancellationToken)
        {
            return Task.FromResult(_employeeService.GetEmployees());
        }
    }
}

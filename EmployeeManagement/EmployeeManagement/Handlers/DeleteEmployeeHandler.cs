using EmployeeManagement.Models;
using EmployeeManagement.Queries;
using EmployeeManagement.Services;
using MediatR;

namespace EmployeeManagement.Handlers
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeById,bool>
    {
        private readonly IEmployeeService _employeeService;

        public DeleteEmployeeHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public Task<bool> Handle(DeleteEmployeeById request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_employeeService.DeleteEmployee(request.EmployeeId));
        }
    }
}

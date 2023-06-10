using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Queries;
using MediatR;

namespace EmployeeManagement.Handlers
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private readonly IDataAccess _dataAccess;

        public GetEmployeeByIdHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Task<Employee> Handle(GetEmployeeByIdQuery request , CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataAccess.GetEmployee(request.EmployeeId));
        }
    }
}

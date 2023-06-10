using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Queries;
using MediatR;

namespace EmployeeManagement.Handlers
{
    public class GetEmployeeListHandler : IRequestHandler<GetEmployeeListQuery , List<Employee>>
    {
        private readonly IDataAccess _dataAccess;

        public GetEmployeeListHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Task<List<Employee>> Handle(GetEmployeeListQuery request , CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataAccess.GetEmployees());
        }
    }
}

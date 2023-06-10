using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Queries;
using MediatR;

namespace EmployeeManagement.Handlers
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeById,bool>
    {
        private readonly IDataAccess _dataAccess;

        public DeleteEmployeeHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Task<bool> Handle(DeleteEmployeeById request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataAccess.DeleteEmployee(request.EmployeeId));
        }
    }
}

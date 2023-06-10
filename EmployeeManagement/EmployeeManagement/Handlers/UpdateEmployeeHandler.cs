using EmployeeManagement.Commands;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using MediatR;

namespace EmployeeManagement.Handlers
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, Employee>
    {
        private readonly IDataAccess _dataAccess;

        public UpdateEmployeeHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public Task<Employee> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataAccess.UpdateEmployee(command));
        }
    }
}

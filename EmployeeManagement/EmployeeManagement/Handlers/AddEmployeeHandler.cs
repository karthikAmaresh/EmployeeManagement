using EmployeeManagement.Commands;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using MediatR;

namespace EmployeeManagement.Handlers
{
    public class AddEmployeeHandler : IRequestHandler<AddEmployeeCommand, Employee>
    {
        private readonly IDataAccess _dataAccess;

        public AddEmployeeHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
         
        public Task<Employee> Handle(AddEmployeeCommand command, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataAccess.AddEmployee(command));
        }
    }
}

using EmployeeManagement.Models;
using MediatR;

namespace EmployeeManagement.Queries
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public int EmployeeId { get; set; }

        public GetEmployeeByIdQuery(int employeeId)
        {
        EmployeeId = employeeId;
        }
    }

}

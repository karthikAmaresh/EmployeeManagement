using MediatR;

namespace EmployeeManagement.Queries
{
    public class DeleteEmployeeById : IRequest<bool>
    {
        public int EmployeeId { get; set; }

        public DeleteEmployeeById(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}

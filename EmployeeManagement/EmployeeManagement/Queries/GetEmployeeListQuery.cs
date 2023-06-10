using EmployeeManagement.Models;
using MediatR;

namespace EmployeeManagement.Queries
{
    public record GetEmployeeListQuery() : IRequest<List<Employee>>;
}

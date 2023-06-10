using EmployeeManagement.Commands;
using EmployeeManagement.Models;

namespace EmployeeManagement.Data
{
    public interface IDataAccess
    {
        List<Employee> GetEmployees();
        Employee GetEmployee(int id);
        Employee AddEmployee(AddEmployeeCommand employee);
        Employee UpdateEmployee(UpdateEmployeeCommand employee);
        bool DeleteEmployee(int id);
    }
}

using EmployeeManagement.Commands;
using EmployeeManagement.Models;

namespace EmployeeManagement.Services
{
    public interface IEmployeeService
    {
        public List<Employee> GetEmployees();
        public Employee GetEmployee(int id);
        public Employee AddEmployee(AddEmployeeCommand employee);
        public Employee UpdateEmployee(UpdateEmployeeCommand employee);
        public bool DeleteEmployee(int id);

    }
}

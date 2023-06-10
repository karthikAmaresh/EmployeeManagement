using EmployeeManagement.Commands;
using EmployeeManagement.Models;

namespace EmployeeManagement.Data
{
    public class DataAccess : IDataAccess
    {
        private List<Employee> _employees = new();

        public DataAccess()
        {
            _employees.Add(new Employee {
                id = 1 ,
                firstName = "Abhi" ,
                lastName = "Ram" ,
                age = 25 ,
                company = "Neudesic" ,
                about = "fresher straight from college with eagerness to learn and grow professionally",
                email="abhi.ram@neudesic.com" ,
                address="Bangalore",
                eyeColor="Brown",
                phone = 9964585858
            });
            _employees.Add(new Employee
            {
                id = 2,
                firstName = "Keerthi",
                lastName = "Raj",
                age = 28,
                company = "IBM",
                about = "2 years experienced",
                email = "keerthi.raj@neudesic.com",
                address = "Bangalore",
                eyeColor = "Black",
                phone = 9881256300
            });
        }

        public List<Employee> GetEmployees()
        {
            return _employees;
        }

        public Employee AddEmployee(AddEmployeeCommand employee)
        {
            Employee newEmployee = new()
            {
                id = _employees.Max(x => x.id) + 1,
                eyeColor = employee.eyeColor,
                about = employee.about,
                address = employee.address,
                age = employee.age,
                company = employee.company,
                email = employee.email,
                firstName = employee.firstName,
                lastName = employee.lastName,
                phone = employee.phone
            };
            return newEmployee;
        }

        public Employee GetEmployee(int id)
        {
            Employee employeeDetails = _employees.FirstOrDefault(x => x.id == id);
            return employeeDetails;
        }

        public Employee UpdateEmployee(UpdateEmployeeCommand employee)
        {
            Employee employeeDetails = _employees.FirstOrDefault(x => x.id == employee.id);
            if(employeeDetails != null)
            {
                employeeDetails.about = employee.about;
                employeeDetails.firstName = employee.firstName;
                employeeDetails.lastName = employee.lastName;
                employeeDetails.eyeColor = employee.eyeColor;
                employeeDetails.company = employee.company;
                employeeDetails.phone = employee.phone;
                employeeDetails.email = employee.email;
                employeeDetails.address = employee.address;
                employeeDetails.age = employee.age;
            }
            return employeeDetails;
        }

        public bool DeleteEmployee(int id)
        {
            Employee employeeDetails = _employees.FirstOrDefault(x => x.id == id);
            _employees.Remove(employeeDetails);
            if(employeeDetails != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

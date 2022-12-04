using EmployeeManagement.Models;
using EmployeeManagement.Repository.Interfaces;

namespace EmployeeManagement.Repository.Implemantation
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList = new List<Employee>();



        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(x => x.Id == Id);
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;
        }

        public Employee add(Employee employee)
        {
            employee.Id = _employeeList.Max(x => x.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employeeList.FirstOrDefault(x => x.Id == employeeChanges.Id);
            if (employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Department = employeeChanges.Department;
                employee.Email = employeeChanges.Email;
            }
            return employee;
        }

        public Employee Delete(int Id)
        {
            Employee employee = _employeeList.FirstOrDefault(x => x.Id == Id);
            if (employee is not null)
            {
                _employeeList.Remove(employee);

            }
            return employee;
        }

        public IEnumerable<Employee> Search(string term, int dept)
        {
            throw new NotImplementedException();
        }
    }
}

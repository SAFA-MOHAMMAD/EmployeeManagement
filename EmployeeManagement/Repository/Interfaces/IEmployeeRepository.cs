using EmployeeManagement.Models;

namespace EmployeeManagement.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int Id);
        IEnumerable<Employee> GetAllEmployee();
        Employee add(Employee employee);
        Employee Update(Employee employeeChanges);
        Employee Delete(int Id);
        IEnumerable<Employee> Search(string term , int dept);

    }
}

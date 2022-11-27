namespace EmployeeManagement.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int Id);
        IEnumerable <Employee> GetAllEmployee();
        Employee add(Employee employee);    
        Employee Update(Employee employeeChanges); 
        Employee Delete(int Id);    
    }
}

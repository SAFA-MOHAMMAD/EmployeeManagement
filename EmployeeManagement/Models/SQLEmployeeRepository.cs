using EmployeeManagement.Context;

namespace EmployeeManagement.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext  _context;
        public SQLEmployeeRepository(AppDbContext context)
        {
            _context = context; 
        }
        public Employee add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;    
        }

        public Employee Delete(int Id)
        {
            Employee employee = _context.Employees.Find(Id);
            if (employee != null) {
                _context.Employees.Remove(employee);
                _context.SaveChanges(true);
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _context.Employees;        }

        public Employee GetEmployee(int Id)
        {
            return _context.Employees.Find(Id);        }

        public Employee Update(Employee employeeChanges)
        {
            var employee = _context.Employees.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return employeeChanges;
        }
    }
}

using EmployeeManagement.Context;
using EmployeeManagement.Models;
using EmployeeManagement.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repository.Implemantation
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _dbContext;
        public SQLEmployeeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Employee add(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
            return employee;
        }

        public Employee Delete(int Id)
        {
            Employee employee = _dbContext.Employees.Find(Id);
            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                _dbContext.SaveChanges(true);
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _dbContext.Employees;
        }

        public Employee GetEmployee(int Id)
        {
            return _dbContext.Employees.Include(d=>d.Department).FirstOrDefault(x=> x.Id == Id);
        }

        public IEnumerable<Employee> Search(string term , int dept)
        {
           

    return _dbContext.Employees.Include(d=>d.Department)
                    .Where (
        x=>((x.Name.Contains(term) ||string.IsNullOrEmpty(term))
        || (x.Email.Contains(term)|| string.IsNullOrEmpty(term))
        ||( x.Department.Name.Contains(term)|| string.IsNullOrEmpty(term)))&&
        (x.DepartmentId.Equals(dept)||dept==-1)
        ).ToList(); 
            
          
                }

        public Employee Update(Employee employeeChanges)
        {
            var employee = _dbContext.Employees.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
            return employeeChanges;
        }
    }
}

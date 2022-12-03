using EmployeeManagement.Models;
using EmployeeManagement.Repository.Interfaces;

namespace EmployeeManagement.Repository.Implemantation
{
    public class EmployeeRepository : IRepository<Employee>
    {
        public Employee add(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Employee EntityDelete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Employee> Search(string term)
        {
            throw new NotImplementedException();
        }

        public Employee Update(Employee entityChange)
        {
            throw new NotImplementedException();
        }
    }
}

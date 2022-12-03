using EmployeeManagement.Context;
using EmployeeManagement.Models;
using EmployeeManagement.Repository.Interfaces;

namespace EmployeeManagement.Repository.Implemantation
{
    public class DepartmentRepository : IRepository<Department>
    {
        private readonly AppDbContext _dbContext;

        public DepartmentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Department add(Department entity)
        {
         _dbContext.Departments.Add(entity);
            _dbContext.SaveChanges();
            return entity;  
        }

        public Department EntityDelete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetAll()
        {
            return _dbContext.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return _dbContext.Departments.FirstOrDefault(x => x.Id == id);
        }

        public IList<Department> Search(string term)
        {
            throw new NotImplementedException();
        }

        public Department Update(Department entityChange)
        {
            throw new NotImplementedException();
        }
    }
}

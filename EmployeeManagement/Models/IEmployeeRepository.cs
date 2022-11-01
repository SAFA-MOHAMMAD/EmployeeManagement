namespace EmployeeManagement.Models
{
    public interface IEmployeeRepository
    {
        Emploeey GetEmployee(int Id);
        IEnumerable <Emploeey> GetAllEmployee();
    }
}

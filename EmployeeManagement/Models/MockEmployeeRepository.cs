namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List <Employee> _employeeList = new List<Employee>();
        public MockEmployeeRepository()
        {
            _employeeList.Add(new Employee() { Id=1,Name="safa", Department = "Softwer Engenering",Email="Safa.emil.com"});
            _employeeList.Add(new Employee() { Id = 2, Name = "sara", Department = "bio Engenering", Email = "sara.emil.com" });
            _employeeList.Add(new Employee() { Id = 3, Name = "saga", Department = "comuter Engenering", Email = "saga.emil.com" });
            _employeeList.Add(new Employee() { Id = 4, Name = "saloa", Department = "chimcal Engenering", Email = "saloa.emil.com" });

        }


        public Employee GetEmployee(int Id)
        {
            return this._employeeList.FirstOrDefault(x => x.Id == Id);
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;
        }
    }
}

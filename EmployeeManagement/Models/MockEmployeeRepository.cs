namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List <Emploeey> _employeeList = new List<Emploeey>();
        public MockEmployeeRepository()
        {
            _employeeList.Add(new Emploeey() { Id=1,Name="safa", Department = "Softwer Engenering",Emil="Safa.emil.com"});
            _employeeList.Add(new Emploeey() { Id = 2, Name = "sara", Department = "bio Engenering", Emil = "sara.emil.com" });
            _employeeList.Add(new Emploeey() { Id = 3, Name = "saga", Department = "comuter Engenering", Emil = "saga.emil.com" });
            _employeeList.Add(new Emploeey() { Id = 4, Name = "saloa", Department = "chimcal Engenering", Emil = "saloa.emil.com" });

        }


        public Emploeey GetEmployee(int Id)
        {
            return this._employeeList.FirstOrDefault(x => x.Id == Id);
        }

        public IEnumerable<Emploeey> GetAllEmployee()
        {
            return _employeeList;
        }
    }
}

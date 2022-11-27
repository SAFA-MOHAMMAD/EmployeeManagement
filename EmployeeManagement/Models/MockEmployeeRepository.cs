namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList = new List<Employee>();
        public MockEmployeeRepository()
        {
            _employeeList.Add(new Employee() { Id = 1, Name = "safa", Department = Dept.SoftwerEngenering, Email = "Safa.Gmail.com" });
            _employeeList.Add(new Employee() { Id = 2, Name = "sara", Department = Dept.BioEngenering, Email = "sara.Gmail.com" });
            _employeeList.Add(new Employee() { Id = 3, Name = "saga", Department = Dept.ComuterEngenering, Email = "saga.emil.com" });
            _employeeList.Add(new Employee() { Id = 4, Name = "saloa", Department = Dept.ChimcalEngenerin, Email = "saloa.emil.com" });

        }


        public Employee GetEmployee(int Id)
        {
            return this._employeeList.FirstOrDefault(x => x.Id == Id);
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
                employee.Name=employeeChanges.Name;
                employee.Department=employeeChanges.Department; 
                employee.Email=employeeChanges.Email;   
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
    }
}

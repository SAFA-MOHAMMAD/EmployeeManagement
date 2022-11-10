using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController
    {
        [Route("[controller]/[action]")]
        public string List()
        {
            return "List() of DepartmentsController";
        }
        public string Detalis()
        {
            return "Details() of DepartmentsController";
        }
    }
}

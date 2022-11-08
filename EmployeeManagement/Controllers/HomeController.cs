using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;   
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        
        
        public ViewResult Index()
        {
            var employee = _employeeRepository.GetAllEmployee();
            ViewBag.PageTitle = "Employee List";
            ViewBag.Title = "";
            return View(employee);
        }
        public ViewResult Details(int? Id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new()
            {
                Emploeey = _employeeRepository.GetEmployee(Id ?? 1),
                PageTitle = "Employee Details"
            };
            return View(homeDetailsViewModel);
        }
    }
}

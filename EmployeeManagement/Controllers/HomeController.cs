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
                Employee = _employeeRepository.GetEmployee(Id ?? 1),
                PageTitle = "Employee Details"
            };
            return View(homeDetailsViewModel);
        }
        [HttpGet]
        public ViewResult Create()
        {
            Employee emploeey = new();
            return View(emploeey);
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee newEmployee = _employeeRepository.add(employee);
                return RedirectToAction("Details", new { Id = newEmployee.Id });
            }
            return View();
        }
    }
}


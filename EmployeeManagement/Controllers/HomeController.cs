using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{

    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public HomeController(IEmployeeRepository employeeRepository,IWebHostEnvironment webHostEnviroment)
        {
            _employeeRepository = employeeRepository;   
            _webHostEnviroment = webHostEnviroment;
        }

      

        public ViewResult Index()
        {
            var employee = _employeeRepository.GetAllEmployee();
            ViewBag.PageTitle = "Employee List";
            ViewBag.Title = "";
            return View(employee);
        }
        public ViewResult Details(int Id)
        {
            
            Employee employee = _employeeRepository.GetEmployee(Id);
            if (employee == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", Id);
            }
            HomeDetailsViewModel homeDetailsViewModel = new()
            {
                Employee = employee,
                PageTitle = "Employee Details"
            };
            return View(homeDetailsViewModel);
        }
        [HttpGet]
        public ViewResult Create()
        {
            HomeCreateViewModel model = new();
            return View(model);
        }
        [HttpPost]

        public IActionResult Create(HomeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName =ProcessUploadedFile(model); ;
                
                Employee newEmployee = new Employee
                {
                    Department = model.Department,
                    Email = model.Email,
                    Name = model.Name,
                    PhotoPath = uniqueFileName
                };
             _employeeRepository.add(newEmployee);
                return RedirectToAction("Details", new { Id = newEmployee.Id });
            }
            return View();
        }
        [HttpGet]
        public ViewResult Edit(int Id)
        {
            Employee employee = _employeeRepository.GetEmployee(Id);

            HomeEditViewModel model = new HomeEditViewModel
            {
                Id = employee.Id,
                Department = employee.Department,
                Email = employee.Email,
                Name = employee.Name,
                ExistingPhotoPath = employee.PhotoPath
            };
            return View(model);
        }
        [HttpPost ] 
        public IActionResult Edit(HomeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _employeeRepository.GetEmployee(model.Id);
                    employee.Department = model.Department;
                    employee.Email = model.Email;
                    employee.Name = model.Name;

                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(_webHostEnviroment.WebRootPath, "Images" , model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }

                    employee.PhotoPath = ProcessUploadedFile(model);
                }

                _employeeRepository.Update(employee);

                return RedirectToAction("Index");
            }
            return View();
        }

        private String ProcessUploadedFile(HomeCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadFolder = Path.Combine(_webHostEnviroment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Employee employee = _employeeRepository.GetEmployee(Id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult ConfirmDelete(int Id)
        {
            Employee employee = _employeeRepository.GetEmployee(Id);
            _employeeRepository.Delete(Id);
            if (employee.PhotoPath != null)
            {
                string filePath = Path.Combine(_webHostEnviroment.WebRootPath, "Images", employee.PhotoPath);
                System.IO.File.Delete(filePath);
            }
            return RedirectToAction("Index");
        }
    }
}


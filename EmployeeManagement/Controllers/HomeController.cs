using EmployeeManagement.Models;
using EmployeeManagement.Repository.Interfaces;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{

    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IRepository<Department> _departmentRepository;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public HomeController(IEmployeeRepository employeeRepository, IWebHostEnvironment webHostEnviroment, IRepository<Department> departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _webHostEnviroment = webHostEnviroment;
            _departmentRepository = departmentRepository;
        }



        public ViewResult Index()
        {
            var employee = _employeeRepository.GetAllEmployee();
            ViewBag.PageTitle = "Employee List";
            ViewBag.Title = "";
            ViewBag.Departments = FillDepartmentList();
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
            HomeCreateViewModel model = new HomeCreateViewModel
            {
                Departments = FillDepartmentList()
            };
            return View(model);
        }
        [HttpPost]

        public IActionResult Create(HomeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName =ProcessUploadedFile(model);
                var Department = _departmentRepository.GetById(model.DepartmentId);
                Employee newEmployee = new Employee
                {
                    Department = Department,
                    DepartmentId=model.DepartmentId,    
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
                DepartmentId = employee.DepartmentId,
                Email = employee.Email,
                Name = employee.Name,
                ExistingPhotoPath = employee.PhotoPath,
                Departments = FillDepartmentList()
            };
            return View(model);
        }
        private List<Department> FillDepartmentList()
        {
            var lstDepartment=_departmentRepository.GetAll();
            lstDepartment.Insert(0, new Department { Id = -1, Name = "Please select Department" });
            return lstDepartment;   
        }
        [HttpPost ] 
        public IActionResult Edit(HomeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _employeeRepository.GetEmployee(model.Id);
                var Department = _departmentRepository.GetById(model.DepartmentId);

                employee.Department = Department;
                    employee.Email = model.Email;
                    employee.Name = model.Name;
                employee.DepartmentId = model.DepartmentId;

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
            return View(model);
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
        public IActionResult Search (string term, int dept) { 

            var employees=_employeeRepository.Search(term);
            return View("Index",employees);
        }
    }
}


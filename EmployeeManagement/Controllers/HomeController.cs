using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace EmployeeManagement.controllers; 

public class HomeController : Controller
{
    private readonly IEmployeeRepository _employeeRepository;    
    public HomeController (IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;   
    }
    public ViewResult index()
    {
        var employee=_employeeRepository.GetAllEmployee();  
        return View(employee); 
    }
    public ViewResult Details()
    {
        HomeDetailsViewModel homeDetailsViewModel = new()
        {
            Emploeey = _employeeRepository.GetEmployee(1),
                PageTitle = "Employee Details"
        };
        
        var employee = _employeeRepository.GetEmployee(1);
        ViewData["employee"] = employee;
        ViewData["PageTitle"] = "Emploeey Details";


        return View(homeDetailsViewModel);  
    }
}

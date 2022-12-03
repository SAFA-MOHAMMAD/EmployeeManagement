using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="The Name feiled is requird")]
        [MaxLength(50,ErrorMessage ="The name should be lwss than 50 characters"),MinLength(4,ErrorMessage ="the minmum is 4 characters")]
        public String Name { get; set; }
        [Display (Name="Ofice Email")]

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",ErrorMessage ="Invalid Email format")]
        public String Email { get; set; }
        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        public string? PhotoPath  { get; set; }
    }
}

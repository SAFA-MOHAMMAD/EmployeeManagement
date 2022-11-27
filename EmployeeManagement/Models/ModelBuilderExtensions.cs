   using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace EmployeeManagement.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "SAFA",
                    Department = Dept.SoftwerEngenering,
                    Email = "Safa.Gmail.com"
                   

                },
                new Employee
                {
                    Id = 2,
                    Name = "SARA",
                    Department = Dept.BioEngenering,
                    Email = "sara.Gmail.com"
                   

                }
                );
        }
    } 

}

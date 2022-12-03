   using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace EmployeeManagement.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Employee>().HasData(
            //    new Employee
            //    {
            //        Id = 1,
            //        Name = "SAFA",
            //        Department = new Department { Id = 1 , Name= "SoftwerEngenering" },
            //        Email = "Safa.Gmail.com",
            //        DepartmentId = 1


            //    },
            //    new Employee
            //    {
            //        Id = 2,
            //        Name = "SARA",
            //        Department = new Department { Id = 1, Name = "BioEngenering" },
            //        Email = "sara.Gmail.com",
            //        DepartmentId = 2

            //    }
            //    );
            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    Id = 1,
                    Name = "SoftwerEngenering",
                    Location = "Amman"
                },
                new Department
                {
                    Id = 2,
                    Name = "ChimcalEngenerin",
                    Location = "Amman"

                },
                new Department
                {
                    Id = 3,
                    Name = "ComuterEngenering",
                    Location = "Amman"
                },
                new Department
                {
                    Id = 4,
                    Name = "BioEngenering",
                    Location = "Amman"
                }
                );
        }
    } 

}

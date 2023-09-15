using Microsoft.EntityFrameworkCore;

namespace WebAppDemo4._0.Models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(

                new Employee
                {
                    Id = 1,
                    Name = "prime",
                    Email = "A@prime.com",
                    Department = Dept.HR
                },
                new Employee
                {
                    Id = 2,
                    Name = "john",
                    Email = "A@john.com",
                    Department = Dept.IT
                }
                );
        }
    }
}

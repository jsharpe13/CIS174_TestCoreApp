using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CIS174_TestCoreApp.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        { }

        public DbSet<Student>Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(
            new Student
            {
                StudentId = 1,
                FirstName = "Mark",
                LastName = "Johnson",
                Grade = "A"
            },
            new Student
            {
                StudentId = 2,
                FirstName = "Sam",
                LastName = "Samson",
                Grade = "B"
            },
            new Student
            {
                StudentId = 3,
                FirstName = "Levi",
                LastName = "Veinkmen",
                Grade = "C"
            },
            new Student
            {
                StudentId = 4,
                FirstName = "Nancy",
                LastName = "Poole",
                Grade = "D"
            },
            new Student
            {
                StudentId = 5,
                FirstName = "Rebecca",
                LastName = "Swanson",
                Grade = "F"
            }
            );
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Projektarbete_Avancerad_.NET.Models;
using System;

namespace Projektarbete_Avancerad_.NET.API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TimeReport> TimeReports { get; set; }
        public DbSet<TimeRepEmployee> TimeRepEmployees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Employees
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeID = 1,
                FirstName = "Jack",
                LastName = "Niklasson",
                Email = "jack@jack.com",
                Phone = "0750030030",
                ProjectID = 1,
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeID = 2,
                FirstName = "Emma",
                LastName = "Whiteside",
                Email = "emma@emma.com",
                Phone = "0788484884",
                ProjectID = 2,
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeID = 3,
                FirstName = "Timothy",
                LastName = "Borgäng",
                Email = "timmo@timmo.com",
                Phone = "0782221121",
                ProjectID = 1,
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeID = 4,
                FirstName = "Alice",
                LastName = "Höök",
                Email = "alice@alice.com",
                Phone = "0789989899",
                ProjectID = 3,
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeID = 5,
                FirstName = "Jonathan",
                LastName = "Björck",
                Email = "jonathan@jonthan.com",
                Phone = "0742421133",
                ProjectID = 3,
            });

            //Seed Projects
            modelBuilder.Entity<Project>().HasData(new Project
            {
                ProjectID = 1,
                ProjectName = "New Website",
            });
            modelBuilder.Entity<Project>().HasData(new Project
            {
                ProjectID = 2,
                ProjectName = "Car building",
            });
            modelBuilder.Entity<Project>().HasData(new Project
            {
                ProjectID = 3,
                ProjectName = "Sleep and eat",
            });

            //Seed TimeReports
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportID = 1,
                Week = 23,
                HoursWorked = 35,
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportID = 2,
                Week = 23,
                HoursWorked = 43,
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportID = 3,
                Week = 23,
                HoursWorked = 25,
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportID = 4,
                Week = 24,
                HoursWorked = 12,
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportID = 5,
                Week = 24,
                HoursWorked = 80,
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportID = 6,
                Week = 24,
                HoursWorked = 22,
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportID = 7,
                Week = 25,
                HoursWorked = 2,
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportID = 8,
                Week = 25,
                HoursWorked = 333,
            });

            //Seed TimeRepEmployee
            modelBuilder.Entity<TimeRepEmployee>().HasData(new TimeRepEmployee
            {
                TimeRepEmployeeID = 1,
                TimeReportID = 1,
                EmployeeID = 1,
            });
            modelBuilder.Entity<TimeRepEmployee>().HasData(new TimeRepEmployee
            {
                TimeRepEmployeeID = 2,
                TimeReportID = 2,
                EmployeeID = 1,
            });
            modelBuilder.Entity<TimeRepEmployee>().HasData(new TimeRepEmployee
            {
                TimeRepEmployeeID = 3,
                TimeReportID = 3,
                EmployeeID = 2,
            });
            modelBuilder.Entity<TimeRepEmployee>().HasData(new TimeRepEmployee
            {
                TimeRepEmployeeID = 4,
                TimeReportID = 4,
                EmployeeID = 3,
            });
            modelBuilder.Entity<TimeRepEmployee>().HasData(new TimeRepEmployee
            {
                TimeRepEmployeeID = 5,
                TimeReportID = 5,
                EmployeeID = 4,
            });
            modelBuilder.Entity<TimeRepEmployee>().HasData(new TimeRepEmployee
            {
                TimeRepEmployeeID = 6,
                TimeReportID = 6,
                EmployeeID = 4,
            });
            modelBuilder.Entity<TimeRepEmployee>().HasData(new TimeRepEmployee
            {
                TimeRepEmployeeID = 7,
                TimeReportID = 7,
                EmployeeID = 5,
            });
            modelBuilder.Entity<TimeRepEmployee>().HasData(new TimeRepEmployee
            {
                TimeRepEmployeeID = 8,
                TimeReportID = 8,
                EmployeeID = 5,
            });

        }
    }
}

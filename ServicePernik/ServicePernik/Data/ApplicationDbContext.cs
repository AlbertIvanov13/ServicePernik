using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServicePernik.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using ServicePernik.Models.Employee;

namespace ServicePernik.Data
{
    public class ApplicationDbContext : IdentityDbContext<ServiceUser>
    {
        public DbSet<Employee> Employees { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<ServicePernik.Models.Employee.CreateEmployeeVM> CreateEmployeeVM { get; set; }
    }
}

﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServicePernik.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using ServicePernik.Models.Employee;
using ServicePernik.Models.Client;

namespace ServicePernik.Data
{
    public class ApplicationDbContext : IdentityDbContext<ServiceUser>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<StatusReservation> StatusReservations { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<ServicePernik.Models.Employee.CreateEmployeeVM> CreateEmployeeVM { get; set; }
        public DbSet<ServicePernik.Models.Client.CreateClientVM> CreateClientVM { get; set; }
        public DbSet<ServicePernik.Models.Client.ClientListingVM> ClientListingVM { get; set; }
        public DbSet<ServicePernik.Models.Employee.EmployeeListingVM> EmployeeListingVM { get; set; }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServicePernik.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicePernik.Data
{
    public class ApplicationDbContext : IdentityDbContext<ServiceUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
    }
}

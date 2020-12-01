using Job_Management_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Job_Management_API.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Company { get; set; }
        public DbSet<Jobs> Jobs  { get; set; }
        public DbSet<Workers> Workers { get; set; }
        public DbSet<Job_Management_API.Models.WorkersJobs> WorkersJobs { get; set; }

    }
}

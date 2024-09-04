using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication04G.Models;

namespace WebApplication04G.Data
{
    public class WebApplication04GContext : DbContext
    {
        public WebApplication04GContext (DbContextOptions<WebApplication04GContext> options) : base(options) { }

        public DbSet<WebApplication04G.Models.Student> Student { get; set; } = default!;
        public DbSet<Fees> Feeses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Login> Register { get; set; }
    }
}

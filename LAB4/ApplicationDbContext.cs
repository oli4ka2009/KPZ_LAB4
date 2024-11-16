using LAB4.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LAB4
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Policy> Policies { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System.Configuration;
using TestProject.Models;

namespace TestProject.DALs
{
    public class CustomerDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public CustomerDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("customerCS"));
        }
        //entities
        public DbSet<Customer> Customers { get; set; }
           
        }
    }


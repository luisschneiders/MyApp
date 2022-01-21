using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CustomerLibrary.Models;
using EmployeeLibrary.Models;
using SupplierLibrary.Models;
using ContactDetailsLibrary.Models;
using LocationLibrary.Models;

namespace HealthCareApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ContactDetails> ContactDetails { get; set; }
        public DbSet<Location> Location { get; set; }

    }
}

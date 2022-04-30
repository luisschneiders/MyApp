using ContactDetailsLibrary.Models;
using DepartmentLibrary.Models;
using EmployeeLibrary.Models;
using LocationLibrary.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthCareApp.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<ContactDetails> ContactDetails { get; set; }
    public DbSet<Location> Location { get; set; }
    public DbSet<Department> Department { get; set; }

}


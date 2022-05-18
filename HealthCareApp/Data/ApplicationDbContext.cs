using AreaLibrary.Models;
using ContactDetailsLibrary.Models;
using DepartmentLibrary.Models;
using EmployeeLibrary.Models;
using LabelLibrary.Models;
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

    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<ContactDetails> ContactDetails => Set<ContactDetails>();
    public DbSet<Location> Location => Set<Location>();
    public DbSet<Department> Department => Set<Department>();
    public DbSet<LabelMop> LabelMop => Set<LabelMop>();
    public DbSet<Area> Area => Set<Area>();

}

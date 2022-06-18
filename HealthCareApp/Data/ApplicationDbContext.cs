using AreaLibrary.Models;
using ContactDetailsLibrary.Models;
using DepartmentLibrary.Models;
using EmployeeLibrary.Models;
using LabelLibrary.Models;
using LocationLibrary.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrackingInventoryLibrary.Models;

namespace HealthCareApp.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> HcaEmployee => Set<Employee>();
    public DbSet<ContactDetails> HcaContactDetails => Set<ContactDetails>();
    public DbSet<Location> HcaLocation => Set<Location>();
    public DbSet<Department> HcaDepartment => Set<Department>();
    public DbSet<LabelMop> HcaLabelMop => Set<LabelMop>();
    public DbSet<Area> HcaArea => Set<Area>();
    public DbSet<TrackingInventoryMop> HcaTrackingInvetoryMop => Set<TrackingInventoryMop>();
}

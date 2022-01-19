using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using EmployeeLibrary.Models;
using System.Data;
using System.Linq;
using ContactDetailsLibrary.Models;

namespace HealthCareApp.Data
{
    public class EmployeeService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmployeeService(ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _applicationDbContext = applicationDbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        // async method to get list of employees
        public async Task<List<Employee>> GetEmployeesAsync()
        {
            UserService userService = new (_httpContextAccessor);

            var employees = await _applicationDbContext.Employees
                .Include(e => e.ContactDetails)
                .Where(e => e.InsertedBy == userService.UserId())
                .OrderByDescending(e => e.CreatedAt)
                .ToListAsync();

            return employees;
        }

        // async method to add new employee
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {

            UserService userService = new UserService(_httpContextAccessor);

            employee.IsActive = true;
            employee.CreatedAt = employee.UpdatedAt = DateTime.UtcNow;
            // Get current logged user ID
            employee.InsertedBy = userService.UserId();

            try
            {
                _applicationDbContext.Employees.Add(employee);
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return employee;
        }
    }
}

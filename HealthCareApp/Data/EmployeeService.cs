using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using EmployeeLibrary.Models;

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
            return await _applicationDbContext.Employees.ToListAsync();
        }

        // async method to add new employee
        public async Task<Employee> AddCustomerAsync(Employee employee)
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

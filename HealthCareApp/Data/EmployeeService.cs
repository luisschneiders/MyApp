using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using EmployeeLibrary.Models;
using ContactDetailsLibrary.Models;
using System.Linq;
using LocationLibrary.Models;
using Microsoft.EntityFrameworkCore;

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
            UserService userService = new UserService(_httpContextAccessor);
            List<Employee> employeeList = new List<Employee>();

            /* Raw query with joins, filters and ordering */
            var query =
                (
                    from employee in _applicationDbContext.Set<Employee>()
                    join contactDetails in _applicationDbContext.Set<ContactDetails>()
                        on employee.ContactDetailsId equals contactDetails.Id
                    join location in _applicationDbContext.Set<Location>()
                        on employee.LocationId equals location.Id
                    where employee.InsertedBy == userService.UserId()
                    orderby employee.CreatedAt descending
                    select new { employee, contactDetails, location}
                ).AsNoTracking();

            foreach (var i in query)
            {
                Employee employeeDetails = new();
                employeeDetails = i.employee;

                if (i.employee.ContactDetailsId == i.contactDetails?.Id)
                {
                    employeeDetails.ContactDetails = i.contactDetails;
                }

                if (i.employee.LocationId == i.location?.Id)
                {
                    employeeDetails.Location = i.location;
                }

                employeeList.Add(employeeDetails);
            }

            return await Task.FromResult(employeeList);
        }

        /*
         * method to get employee by ID
         */
        public Employee GetEmployeeById(Guid guid)
        {
            try
            {
                UserService userService = new UserService(_httpContextAccessor);

                /* Raw query with joins, filters and ordering */
                var query =
                    (
                        from employee in _applicationDbContext.Set<Employee>()
                        join contactDetails in _applicationDbContext.Set<ContactDetails>()
                            on employee.ContactDetailsId equals contactDetails.Id
                        join location in _applicationDbContext.Set<Location>()
                            on employee.LocationId equals location.Id
                        where employee.Id == guid
                        select new { employee, contactDetails, location }
                    ).AsNoTracking().FirstOrDefault();

                Employee employeeDetails = new();

                employeeDetails = query.employee;

                if (query.employee.ContactDetailsId == query.contactDetails?.Id)
                {
                    employeeDetails.ContactDetails = query.contactDetails;
                }

                if (query.employee.LocationId == query.location?.Id)
                {
                    employeeDetails.Location = query.location;
                }
                return employeeDetails;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         * async method to add new employee
         */
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

        /*
         * async method to update employee
         */
        public async Task<bool> UpdateEmployeeAsync(Employee employee)
        {
            employee.UpdatedAt = DateTime.UtcNow;

            try
            {
                _applicationDbContext.Employees.Update(employee);
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }

    }
}

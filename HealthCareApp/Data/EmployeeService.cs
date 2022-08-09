using EmployeeLibrary.Models;
using ContactDetailsLibrary.Models;
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
                employeeList.Add(SetEmployeeDetails(i.employee, i.contactDetails, i.location));
            }

            return await Task.FromResult(employeeList);
        }

        // async method get list of employees

        public async Task<List<EmployeeListDto>> GetEmployeeListDtoAsync()
        {
            List<EmployeeListDto> employeeListDto = new();

            var query =
                (
                    from employee in _applicationDbContext.Set<Employee>()
                    join contactDetails in _applicationDbContext.Set<ContactDetails>()
                        on employee.ContactDetailsId equals contactDetails.Id
                    orderby employee.CreatedAt descending
                    select new { employee, contactDetails }
                ).AsNoTracking();

            foreach (var i in query)
            {
                employeeListDto.Add(SetEmployeeListDtoDetails(i.employee, i.contactDetails));
            }

            return await Task.FromResult(employeeListDto);
        }


        //public async Task<List<Employee>> SearchAsync(string searchTerm)
        //{
        //    UserService userService = new UserService(_httpContextAccessor);
        //    List<Employee> employeeList = new List<Employee>();

        //    if (string.IsNullOrWhiteSpace(searchTerm))
        //    {
        //        return await Task.FromResult(employeeList);
        //    }

        //    var query =
        //        (
        //            from employee in _applicationDbContext.Set<Employee>()
        //            join contactDetails in _applicationDbContext.Set<ContactDetails>()
        //                on employee.ContactDetailsId equals contactDetails.Id
        //            join location in _applicationDbContext.Set<Location>()
        //                on employee.LocationId equals location.Id
        //            where employee.InsertedBy == userService.UserId()
        //            && (EF.Functions.Like(employee.EmployeeFirstName, $"%{searchTerm}%")
        //            || EF.Functions.Like(employee.EmployeeLastName, $"%{searchTerm}%")
        //            || EF.Functions.Like(employee.EmployeeUsername, $"%{searchTerm}%"))
        //            orderby employee.CreatedAt descending
        //            select new { employee, contactDetails, location }
        //        ).AsNoTracking();

        //    foreach (var i in query)
        //    {
        //        employeeList.Add(SetEmployeeDetails(i.employee, i.contactDetails, i.location));
        //    }

        //    return await Task.FromResult(employeeList);
        //}

        public async Task<List<EmployeeListDto>> SearchEmployeeListDtoAsync(string searchTerm)
        {
            UserService userService = new UserService(_httpContextAccessor);
            List<EmployeeListDto> employeeListDto = new ();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await Task.FromResult(employeeListDto);
            }

            var query =
                (
                    from employee in _applicationDbContext.Set<Employee>()
                    join contactDetails in _applicationDbContext.Set<ContactDetails>()
                        on employee.ContactDetailsId equals contactDetails.Id
                    where EF.Functions.Like(employee.EmployeeFirstName, $"%{searchTerm}%")
                    || EF.Functions.Like(employee.EmployeeLastName, $"%{searchTerm}%")
                    orderby employee.CreatedAt descending
                    select new { employee, contactDetails }
                ).AsNoTracking();

            foreach (var i in query)
            {
                employeeListDto.Add(SetEmployeeListDtoDetails(i.employee, i.contactDetails));
            }

            return await Task.FromResult(employeeListDto);
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

                return SetEmployeeDetails(query.employee, query.contactDetails, query.location);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                throw;
            }
        }

        public async Task<int> CountActiveEmployeeAsync()
        {
            UserService userService = new UserService(_httpContextAccessor);

            int countUsers =
                (
                    from employee in _applicationDbContext.Set<Employee>()
                    where employee.IsActive == true
                    select new { employee }
                ).AsNoTracking().Count();

            return await Task.FromResult(countUsers);
        }

        /*
         * async method to add new employee
         */
        public async Task AddEmployeeAsync(Employee employee)
        {

            UserService userService = new UserService(_httpContextAccessor);

            employee.IsActive = true;
            employee.CreatedAt = employee.UpdatedAt = DateTime.UtcNow;
            // Get current logged user ID
            employee.InsertedBy = userService.UserId();

            try
            {
                _applicationDbContext.HcaEmployee.Add(employee);
                await _applicationDbContext.SaveChangesAsync();

                /*
                 * Because we are using AsNoTracking() in our query, 
                 * we need to detach all state entities with EntityState.Detached
                 * to avoid exception when adding a record or updating the same record more than once
                 */
                _applicationDbContext.Entry(employee).State = EntityState.Detached;
                _applicationDbContext.Entry(employee.ContactDetails).State = EntityState.Detached;
                _applicationDbContext.Entry(employee.Location).State = EntityState.Detached;

                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                await Task.CompletedTask;
            }

        }

        /*
         * async method to update employee
         */
        public async Task UpdateEmployeeAsync(Employee employee)
        {
            employee.UpdatedAt = DateTime.UtcNow;

            try
            {
                _applicationDbContext.HcaEmployee.Update(employee);
                await _applicationDbContext.SaveChangesAsync();

                /*
                 * Because we are using AsNoTracking() in our query, 
                 * we need to detach all state entities with EntityState.Detached
                 * to avoid exception when adding a record or updating the same record more than once
                 */
                _applicationDbContext.Entry(employee).State = EntityState.Detached;
                _applicationDbContext.Entry(employee.ContactDetails).State = EntityState.Detached;
                _applicationDbContext.Entry(employee.Location).State = EntityState.Detached;

                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                await Task.CompletedTask;
            }

        }

        /*
         * async method to update Employee status
         */
        public async Task UpdateEmployeeStatusAsync(Employee employee)
        {
            try
            {

                Employee employeeUpdated = new();

                employeeUpdated = GetEmployeeById(employee.Id);
                employeeUpdated.IsActive = employee.IsActive;
                employeeUpdated.UpdatedAt = DateTime.UtcNow;

                _applicationDbContext.HcaEmployee.Update(employeeUpdated);
                await _applicationDbContext.SaveChangesAsync();

                /*
                 * Because we are using AsNoTracking() in our query, 
                 * we need to detach all state entities with EntityState.Detached
                 * to avoid exception when adding a record or updating the same record more than once
                 */
                _applicationDbContext.Entry(employeeUpdated).State = EntityState.Detached;

                await Task.CompletedTask;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                await Task.CompletedTask;
            }

        }

        private static Employee SetEmployeeDetails(Employee employee, ContactDetails contactDetails, Location location)
        {
            Employee employeeDetails = employee;

            if (employee.ContactDetailsId == contactDetails?.Id)
            {
                employeeDetails.ContactDetails = contactDetails;
            }

            if (employee.LocationId == location?.Id)
            {
                employeeDetails.Location = location;
            }

            return employeeDetails;
        }

        private static EmployeeListDto SetEmployeeListDtoDetails(Employee employee, ContactDetails contactDetails)
        {
            EmployeeListDto employeeListDto = new();

            employeeListDto.Id = employee.Id;
            employeeListDto.EmployeeFirstName = employee.EmployeeFirstName;
            employeeListDto.EmployeeLastName = employee.EmployeeLastName;
            employeeListDto.IsActive = employee.IsActive;

            if (employee.ContactDetailsId == contactDetails?.Id)
            {
                employeeListDto.EmployeeEmail = contactDetails.Email;
            }

            return employeeListDto;
        }
    }
}

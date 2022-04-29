using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DepartmentLibrary.Models;
using Microsoft.AspNetCore.Http;

namespace HealthCareApp.Data
{
    public class DepartmentService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DepartmentService(ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _applicationDbContext = applicationDbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        // async method to get list of departments
        public async Task<List<Department>> GetDepartmentsAsync()
        {
            UserService userService = new UserService(_httpContextAccessor);
            List<Department> departmentList = new List<Department>();

            /* Raw query with joins, filters and ordering */
            //var query =
            //    (
            //        from department in _applicationDbContext.Set<Department>()
            //        where department.InsertedBy == userService.UserId()
            //        orderby department.CreatedAt descending
            //        select new { department }
            //    ).AsNoTracking();

            //foreach (var i in query)
            //{
            //    departmentList.Add(SetDepartmentDetails(i.department));
            //}

            return await Task.FromResult(departmentList);
        }

        private static Department SetDepartmentDetails(Department department)
        {
            Department departmentDetails;

            departmentDetails = department;

            return departmentDetails;
        }
    }
}

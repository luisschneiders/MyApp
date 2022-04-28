using System;
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

    }
}

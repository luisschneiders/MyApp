using System;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace HealthCareApp.Data
{
    public class UserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        // constructor
        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid UserId()
        {

            var principal = _httpContextAccessor.HttpContext.User;
            var loggedInUserId = principal.FindFirstValue(ClaimTypes.NameIdentifier);

            return new Guid(loggedInUserId);

        }
    }
}

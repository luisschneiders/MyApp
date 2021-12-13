using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SupplierLibrary;

namespace HealthCareApp.Data
{
    public class SupplierService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        // Constructor
        public SupplierService(ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _applicationDbContext = applicationDbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        // async method to add new supplier
        public async Task<Supplier> AddSupplierAsync(Supplier supplier)
        {
            UserService userService = new UserService(_httpContextAccessor);

            supplier.IsActive = true;
            supplier.CreatedAt = supplier.UpdatedAt = DateTime.UtcNow;
            // Get current logged user ID
            supplier.InsertedBy = userService.UserId();

            try
            {
                _applicationDbContext.Suppliers.Add(supplier);
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return supplier;
        }
    }
}

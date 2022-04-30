using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using CustomerLibrary.Models;

namespace HealthCareApp.Data
{
    public class CustomerService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        // Constructor
        public CustomerService(ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _applicationDbContext = applicationDbContext;
            _httpContextAccessor = httpContextAccessor;
        }


        // async method to get list of customers
        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _applicationDbContext.Customers.ToListAsync();
        }

        // async method to add new customer
        public async Task<Customer> AddCustomerAsync(Customer customer)
        {

            UserService userService = new UserService(_httpContextAccessor);

            customer.IsActive = true;
            customer.CreatedAt = customer.UpdatedAt  = DateTime.UtcNow;
            // Get current logged user ID
            customer.InsertedBy = userService.UserId();

            try
            {
                _applicationDbContext.Customers.Add(customer);
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return customer;
        }
    }
}

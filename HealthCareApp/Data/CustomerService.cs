using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CustomerLibrary;

namespace HealthCareApp.Data
{
    public class CustomerService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        // Constructor
        public CustomerService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        // async method to get list of customers
        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _applicationDbContext.Customers.ToListAsync();
        }

        // async method to add new customer
        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
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

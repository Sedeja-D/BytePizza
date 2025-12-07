///Details what the services need to do but not how it needs to be done.
using Microsoft.EntityFrameworkCore;
using BytePizza.Models;
using BytePizza.Data;
using BytePizza.Services.Interfaces;

namespace BytePizza.Services.Implementions
{
    public class CustomerService : ICustomerService
    {
        public Task<Customer?> GetCustomerAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> LoginAsync(string phone, string password)
        {
            throw new NotImplementedException();
        }
    }
}

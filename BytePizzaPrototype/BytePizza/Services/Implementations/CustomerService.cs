///Details what the services need to do but not how it needs to be done.
using Microsoft.EntityFrameworkCore;
using BytePizza.Models;
using BytePizza.Data;
using BytePizza.Services.Interfaces;
using System.Diagnostics.Eventing.Reader;

namespace BytePizza.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDBContext _context;

        //storing ID in memory
        private static int? CustomerID = null;

        public CustomerService(ApplicationDBContext context)
        {
            _context = context;
        }

        //get logged in customerID, returns null for logged out.
        public async Task<Customer?> GetCustomerAsync()
        {
            if (CustomerID == null)
            {
                //not logged in
                return null;
            }

            
            else
            {
                //wait for DB response and return ID
                return await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == CustomerID.Value);
            }  
        }

        //Auth customer login with PN + PW; stores CustomerID on success.
        public async Task<bool> LoginAsync(string phone, string password)
        {
            //wait for DB response for phone
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Phone == phone);

            if (customer == null)
            {
                //if phone doesn't exist, return false.
                return false;
            }

            if (customer.Password != password)
            {
                //check for correct password for given PN
                return false;
            }

            //logged in; set CustomerID in memory
            CustomerID = customer.CustomerId;
            return true;
        }

        //wipes CustomerID
        public void Logout()
        {
            CustomerID = null;
        }
    }
}

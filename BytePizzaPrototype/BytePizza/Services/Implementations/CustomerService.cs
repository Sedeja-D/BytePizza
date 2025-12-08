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

        //Sign-up
        public async Task<bool> SignUpAsync(string name, string phone, string address, string password)
        {
            //check that fields are filled and PN is 10 digits
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            if (string.IsNullOrEmpty(phone) || phone.Length != 10)
            {
                return false;
            }
            if (string.IsNullOrEmpty(address))
            {
                return false;
            }
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            //existing if phone number already in DB
            var existing = await _context.Customers.FirstOrDefaultAsync(c => c.Phone == phone);

            if (existing != null)
            {
                return false;
            }

            //checks passed, create customer
            var newCustomer = new Customer
            {
                Name = name,
                Phone = phone,
                Address = address,
                Password = password
            };

            //add customer to DB
            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();

            return true;
        }

        //wipes CustomerID
        public void Logout()
        {
            CustomerID = null;
        }
    }
}

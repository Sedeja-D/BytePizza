///Tells the system WHAT the customer data needs to do. Tasks: load menu items and their prices from the database, get items by category 
///such as size, crust, toppings and beverages. Tasks: Authenticate customers via login and logout and verify 
///customer details against database records.
using BytePizza.Models;

namespace BytePizza.Services.Interfaces
{
    public interface ICustomerService
    {
        ///<summary>
        ///Customer phone number and passwrod used for authentication.
        ///</summary>
        Task<bool> LoginAsync(string phone, string password);

        ///<summary>
        ///Form of state management representing currently authenticated customer
        ///</summary>
        Task<Customer?> GetCustomerAsync();
    }
}

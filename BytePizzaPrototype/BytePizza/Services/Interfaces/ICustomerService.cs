///Tells the system WHAT the customer data needs to do.
///Tasks: Authenticate customers via login and logout and verify customer details against database records.
using BytePizza.Models;

namespace BytePizza.Services.Interfaces
{
    public interface ICustomerService
    {

        ///<summary>
        ///Logs in customer using Phone + Pass
        ///</summary>
        ///<param name="phone">10 Digit Number</param>
        ///<param name="password">User Password</param>
        ///<returns> True for login, False for incorrect info</returns>
        Task<bool> LoginAsync(string phone, string password);

        ///<summary>
        ///Form of state management representing currently authenticated customer
        ///</summary>
        ///<returns> CustomerID or Null for logged out </returns>
        Task<Customer?> GetCustomerAsync();

        ///<summary>
        ///Logout customer; wiping CustomerID
        ///</summary>
        void Logout();
    }
}

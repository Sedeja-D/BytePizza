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

        /// <summary>
        /// Creates a new customer
        /// </summary>
        /// <param name="name">Customer Name</param>
        /// <param name="phone">Phone number</param>
        /// <param name="address">Address</param>
        /// <param name="password">Password</param>
        /// <returns>True for successful creation, false for failure</returns>
        Task<bool> SignUpAsync(string name, string phone, string address, string password);

        /// <summary>
        /// Allows user to reset password with valid phone number and a new password
        /// Could later be tied to a text/email verification
        /// </summary>
        /// <param name="phone">User's phone number</param>
        /// <param name="newPassword">User's new password</param>
        /// <returns>True for successful reset, false for failed reset</returns>
        Task<bool> ResetPasswordAsync(string phone, string newPassword);

        ///<summary>
        ///Logout customer; wiping CustomerID
        ///</summary>
        void Logout();
    }
}

///Tells the system WHAT the menu data needs to do. Tasks: load menu items and their prices from the database, get items by category 
///such as size, crust, toppings and beverages.
using BytePizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BytePizza.Services.Interfaces
{
    public interface IMenuService
    {
        ///<returns>List of tuples; (Name, Price)</returns>
        Task<List<(string Name, decimal Price)>> GetToppingsAsync();

        ///<returns>List of tuples; (Name, Price)</returns>
        Task<List<(string Name, decimal Price)>> GetPizzaSizesAsync();

        ///<returns>List of tuples; (Name, Price)</returns>
        Task<List<(string Name, decimal Price)>> GetPizzaCrustsAsync();

        ///<returns>List of tuples; (Name, Price)</returns>
        Task<List<(string Name, decimal Price)>> GetDrinksAsync();

        ///<returns>List of tuples; (Name, Price)</returns>
        Task<List<(string Name, decimal Price)>> GetDrinkSizesAsync();
    }
}

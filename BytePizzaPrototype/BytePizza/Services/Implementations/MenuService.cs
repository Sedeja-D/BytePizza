///Implements the menu interface tasks. This is the HOW. Therfore this is the code which
///makes queries to the database for MenuItem, returns the data to be used in the order form,
///and provides pricing data.
using BytePizza.Data;
using BytePizza.Models;
using BytePizza.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Ribbon.Primitives;
using Microsoft.EntityFrameworkCore;

namespace BytePizza.Services.Implementations
{
    public class MenuService : IMenuService
    {
        private readonly ApplicationDBContext _context;

        public MenuService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<(string Name, decimal Price)>> GetToppingsAsync()
        {
            //Wait for DB response and return available toppings category options, project to anon object w/ only name and price
            var toppings = await _context.MenuItems
                .Where(m => m.Category == "Topping")
                .Select(m => new { m.Name, m.MenuItemPrice })
                .ToListAsync();

            //convert to list of tuples. Each tuple being (name, price)
            return toppings.Select(t => (t.Name, Price: t.MenuItemPrice)).ToList();
        }

        public async Task<List<(string Name, decimal Price)>> GetPizzaSizesAsync()
        {
            //Wait for DB response and return available sizes category options, project to anon object w/ only name and price
            var PizzaSizes = await _context.MenuItems
                .Where(m => m.Category == "PizzaSize")
                .Select(m => new { m.Name, m.MenuItemPrice })
                .ToListAsync();

            //convert to list of tuples. Each tuple being (name, price)
            return PizzaSizes.Select(s => (s.Name, Price: s.MenuItemPrice)).ToList();
        }

        public async Task<List<(string Name, decimal Price)>> GetPizzaCrustsAsync()
        {
            //Wait for DB response and return available crust category options, project to anon object w/ only name and price
            var crust = await _context.MenuItems
                .Where(m => m.Category == "Crust")
                .Select(m => new { m.Name, m.MenuItemPrice })
                .ToListAsync();

            //convert to list of tuples. Each tuple being (name, price)
            return crust.Select(c => (c.Name, Price: c.MenuItemPrice)).ToList();
        }

        public async Task<List<(string Name, decimal Price)>> GetDrinksAsync()
        {
            //Get unique drink names from all drink categories (Drink-Small, Drink-Medium, Drink-Large)
            var drinks = await _context.MenuItems
                .Where(m => m.Category.StartsWith("Drink-"))
                .Select(m => m.Name)
                .Distinct()
                .ToListAsync();

            //Return drinks with 0 price since pricing is determined by size
            return drinks.Select(d => (Name: d, Price: 0m)).ToList();
        }

        public async Task<List<(string Name, decimal Price)>> GetDrinkSizesAsync()
        {
            //Get drink sizes by extracting the size from category name (e.g., "Drink-Small" -> "Small")
            //Use Fountain Soda as the reference drink for pricing
            var drinkSizes = await _context.MenuItems
                .Where(m => m.Category.StartsWith("Drink-") && m.Name == "Fountain Soda")
                .Select(m => new {
                    Size = m.Category.Replace("Drink-", ""),
                    m.MenuItemPrice
                })
                .ToListAsync();

            //convert to list of tuples. Each tuple being (size name, price)
            return drinkSizes.Select(s => (s.Size, Price: s.MenuItemPrice)).ToList();
        }

        public async Task<List<(string Name, decimal Price)>> GetSaucesAsync()
        {
            //Wait for DB response and return available sauce category options, project to anon object w/ only name and price
            var sauces = await _context.MenuItems
                .Where(m => m.Category == "Sauce")
                .Select(m => new { m.Name, m.MenuItemPrice })
                .ToListAsync();

            //convert to list of tuples. Each tuple being (name, price)
            return sauces.Select(s => (s.Name, Price: s.MenuItemPrice)).ToList();
        }

        public async Task<decimal> GetDrinkPriceAsync(string drinkName, string size)
        {
            //Get specific drink price based on name and size
            var category = $"Drink-{size}";

            var drinkPrice = await _context.MenuItems
                .Where(m => m.Name == drinkName && m.Category == category)
                .Select(m => m.MenuItemPrice)
                .FirstOrDefaultAsync();

            return drinkPrice;
        }
    }
}
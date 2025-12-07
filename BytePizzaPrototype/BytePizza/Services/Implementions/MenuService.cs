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

namespace BytePizza.Services.Implementions
{
    internal class MenuService : IMenuService
    {
        private readonly ApplicationDBContext _context;

        public MenuService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<(string Name, decimal Price)>> GetToppingsAsync()
        {
            //Wait for DB response and return available toppings category options, project to anon object w/ only name and price
            var toppings = await _context.MenuItems.Where(m => m.Category == "Topping" ).Select(m => new {m.Name, m.MenuItemPrice }).ToListAsync();

            //convert to list of tuples. Each tuple being (name, price)
            return toppings.Select(t => (Name: t.Name, Price: t.MenuItemPrice)).ToList();
        }

        public async Task<List<(string Name, decimal Price)>> GetPizzaSizesAsync()
        {
            //Wait for DB response and return available sizes category options, project to anon object w/ only name and price
            var PizzaSizes = await _context.MenuItems.Where(m => m.Category == "PizzaSize").Select(m => new { m.Name, m.MenuItemPrice }).ToListAsync();

            //convert to list of tuples. Each tuple being (name, price)
            return PizzaSizes.Select(s => (Name: s.Name, Price: s.MenuItemPrice)).ToList();
        }

        public async Task<List<(string Name, decimal Price)>> GetPizzaCrustsAsync()
        {
            //Wait for DB response and return available sizes category options, project to anon object w/ only name and price
            var crust = await _context.MenuItems.Where(m => m.Category == "Crust").Select(m => new { m.Name, m.MenuItemPrice }).ToListAsync();

            //convert to list of tuples. Each tuple being (name, price)
            return crust.Select(c => (Name: c.Name, Price: c.MenuItemPrice)).ToList();
        }

        public async Task<List<(string Name, decimal Price)>> GetDrinksAsync()
        {
            //Wait for DB response and return available sizes category options, project to anon object w/ only name and price
            var drinks = await _context.MenuItems.Where(m => m.Category == "Drink").Select(m => new { m.Name, m.MenuItemPrice }).ToListAsync();

            //convert to list of tuples. Each tuple being (name, price)
            return drinks.Select(d => (Name: d.Name, Price: d.MenuItemPrice)).ToList();
        }

        public async Task<List<(string Name, decimal Price)>> GetDrinkSizesAsync()
        {
            //Wait for DB response and return available sizes category options, project to anon object w/ only name and price
            var DrinkSizes = await _context.MenuItems.Where(m => m.Category == "DrinkSize").Select(m => new { m.Name, m.MenuItemPrice }).ToListAsync();

            //convert to list of tuples. Each tuple being (name, price)
            return DrinkSizes.Select(s => (Name: s.Name, Price: s.MenuItemPrice)).ToList();
        }
    }
}

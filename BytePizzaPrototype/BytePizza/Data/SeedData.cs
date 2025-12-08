///Seeds the database with demo users at runtime. Add default customer login combinations methods here.

using Microsoft.EntityFrameworkCore;
using BytePizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BytePizza.Data
{
    public static class SeedData
    {
        ///<summary>
        ///Customer accounts seeded into database
        ///</summary>
        public static void Initialize(ApplicationDBContext context)
        {
            context.Database.EnsureCreated();
            //Checks for seeded data within database to prevent duplication
            if (context.Customers.Any())
            {
                return;
            }
            //Seed database with test customers (login with phone numbers & passwords)
            var customers = new List<Customer>
                {
                    new Customer
                    {
                        Phone = "5551234567",
                        Password = "pizza",
                        Name = "John Doe",
                        Address = "123 Main Street"
                    },
                    new Customer
                    {
                        Phone = "5559876543",
                        Password = "secret",
                        Name = "Jane Smith",
                        Address = "456 Oak Avenue"
                    },
                    new Customer
                    {
                        Phone = "5550000000",
                        Password = "1234",
                        Name = "Test User",
                        Address = "789 Test Lane"
                    },
                };
            
            context.Customers.AddRange(customers);
            context.SaveChanges();

            if (!context.MenuItems.Any())
            {
                var menu = new List<MenuItem>
                {
                    // Pizza Sizes
                    new MenuItem { Name = "Byte", Category = "PizzaSize", MenuItemPrice = 9.99m },
                    new MenuItem { Name = "Kilo", Category = "PizzaSize", MenuItemPrice = 12.99m },
                    new MenuItem { Name = "Mega", Category = "PizzaSize", MenuItemPrice = 14.99m },
                    new MenuItem { Name = "Giga", Category = "PizzaSize", MenuItemPrice = 16.99m },
                    new MenuItem { Name = "Tera", Category = "PizzaSize", MenuItemPrice = 19.99m },

                    // Crust Options
                    new MenuItem { Name = "Thin Crust", Category = "Crust", MenuItemPrice = 0.00m },
                    new MenuItem { Name = "Hand-Tossed", Category = "Crust", MenuItemPrice = 0.00m },
                    new MenuItem { Name = "Deep Dish", Category = "Crust", MenuItemPrice = 0.00m },

                    // Toppings
                    new MenuItem { Name = "Pepperoni", Category = "Topping", MenuItemPrice = 1.00m },
                    new MenuItem { Name = "Provolone", Category = "Topping", MenuItemPrice = 1.00m },
                    new MenuItem { Name = "Parmesan Blend", Category = "Topping", MenuItemPrice = 1.00m },
                    new MenuItem { Name = "Bacon", Category = "Topping", MenuItemPrice = 1.00m },
                    new MenuItem { Name = "Chicken", Category = "Topping", MenuItemPrice = 1.00m },
                    new MenuItem { Name = "Sausage", Category = "Topping", MenuItemPrice = 1.00m },
                    new MenuItem { Name = "Mushrooms", Category = "Topping", MenuItemPrice = 1.00m },
                    new MenuItem { Name = "Spinach", Category = "Topping", MenuItemPrice = 1.00m },
                    new MenuItem { Name = "Pineapple", Category = "Topping", MenuItemPrice = 1.00m },
                    new MenuItem { Name = "Mozzarella", Category = "Topping", MenuItemPrice = 1.00m },
                    new MenuItem { Name = "Steak", Category = "Topping", MenuItemPrice = 1.00m },
                    new MenuItem { Name = "Banana Peppers", Category = "Topping", MenuItemPrice = 1.00m },
                    new MenuItem { Name = "Onions", Category = "Topping", MenuItemPrice = 1.00m },
                    new MenuItem { Name = "Black Olives", Category = "Topping", MenuItemPrice = 1.00m },

                    // Sauces
                    new MenuItem { Name = "Marinara", Category = "Sauce", MenuItemPrice = 0.00m },
                    new MenuItem { Name = "Alfredo", Category = "Sauce", MenuItemPrice = 0.00m },
                    new MenuItem { Name = "BBQ", Category = "Sauce", MenuItemPrice = 0.00m },

                    // Drinks
                    new MenuItem { Name = "Fountain Soda", Category = "Drink-Small", MenuItemPrice = 1.79m },
                    new MenuItem { Name = "Fountain Soda", Category = "Drink-Medium", MenuItemPrice = 2.29m },
                    new MenuItem { Name = "Fountain Soda", Category = "Drink-Large", MenuItemPrice = 2.79m },

                    new MenuItem { Name = "Sparkling Water", Category = "Drink-Small", MenuItemPrice = 1.79m },
                    new MenuItem { Name = "Sparkling Water", Category = "Drink-Medium", MenuItemPrice = 2.29m },
                    new MenuItem { Name = "Sparkling Water", Category = "Drink-Large", MenuItemPrice = 2.79m },

                    new MenuItem { Name = "Iced Tea", Category = "Drink-Small", MenuItemPrice = 1.79m },
                    new MenuItem { Name = "Iced Tea", Category = "Drink-Medium", MenuItemPrice = 2.29m },
                    new MenuItem { Name = "Iced Tea", Category = "Drink-Large", MenuItemPrice = 2.79m },

                    new MenuItem { Name = "Coffee", Category = "Drink-Small", MenuItemPrice = 1.79m },
                    new MenuItem { Name = "Coffee", Category = "Drink-Medium", MenuItemPrice = 2.29m },
                    new MenuItem { Name = "Coffee", Category = "Drink-Large", MenuItemPrice = 2.79m },

                    new MenuItem { Name = "Lemonade", Category = "Drink-Small", MenuItemPrice = 1.79m },
                    new MenuItem { Name = "Lemonade", Category = "Drink-Medium", MenuItemPrice = 2.29m },
                    new MenuItem { Name = "Lemonade", Category = "Drink-Large", MenuItemPrice = 2.79m }
                };
                context.MenuItems.AddRange(menu);
                context.SaveChanges();
            }
        }
      }
    }

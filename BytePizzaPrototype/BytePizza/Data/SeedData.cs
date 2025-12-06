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
                }
            };
            context.Customers.AddRange(customers);
            context.SaveChanges();
        }
    }
}

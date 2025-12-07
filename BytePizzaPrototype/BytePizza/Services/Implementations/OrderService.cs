///Tells the system WHAT the order data needs to do. Called by UI Components. Task: Create new orders, calculate order totals
///& save orders to the database. Focuses on tasks not implementation of tasks
using BytePizza.Data;
using BytePizza.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BytePizza.Services.Interfaces;

namespace BytePizza.Services.Implementations
{
    //Order creation and info/status retrieval
    public class OrderService : IOrderService
    {
        private readonly ApplicationDBContext _context;

        public OrderService(ApplicationDBContext context)
        {
            _context = context;
        }

        //creates new order with pizza & drinks and calculates total and tax
        public async Task<Order> CreateOrderAsync(int customerId, string orderType, PizzaOrder pizza, List<DrinkOrder> beverages, decimal taxRate)
        {

            //subtotal calculation
            decimal subtotal = pizza.PizzaOrderPrice + beverages.Sum(d => d.DrinkOrderPrice * d.DrinkQuantity);

            decimal tax = subtotal * taxRate;

            decimal total = subtotal + tax;

            //order ent
            var order = new Order
            {
                CustomerId = customerId,
                OrderType = orderType,
                Tax = tax,
                Total = total,
                Subtotal = subtotal,
                Pizza = pizza,
                Drinks = beverages,
                OrderStatus = "Pending"
            };

            //associate pizza and drinks to order
            pizza.Order = order;
            foreach (var drink in beverages)
            {
                drink.Order = order;
            }

            //save order to DB
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            await _context.Entry(order).Reference(o => o.Pizza).LoadAsync();
            await _context.Entry(order).Collection(o => o.Drinks).LoadAsync();

            return order;



        }


        //pull order ID from DB
        public async Task<Order?> GetOrderByIdAsync(int orderId)
        {
            return await _context.Orders.Include(o => o.Pizza).Include(o => o.Drinks).FirstOrDefaultAsync(o => o.OrderId == orderId);
        }
    }
}

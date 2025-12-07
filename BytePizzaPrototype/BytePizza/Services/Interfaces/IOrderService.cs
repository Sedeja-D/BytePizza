///Tells the system WHAT the order data needs to do. Called by UI Components. Task: Create new orders, calculate order totals
///& save orders to the database. Focuses on tasks not implementation of tasks
using BytePizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BytePizza.Services.Interfaces
{
    public interface IOrderService
    {
        /// <summary>
        /// creates new order with a pizza and beverages
        /// calculates total and taxes
        /// </summary>
        /// <param name="customerId">ID of customer ordering</param>
        /// <param name="orderType">Ordertype of pending be default</param>
        /// <param name="pizza">PizzaOrder object</param>
        /// <param name="beverages">List of BeverageOrder objects</param>
        /// <param name="taxRate">tax rate defined as decimal (ex. 8% would be input as 0.08.)</param>
        /// <returns></returns>
        Task<Order> CreateOrderAsync(int customerId, string orderType, PizzaOrder pizza, List<DrinkOrder> beverages, decimal taxRate = .08m);

        /// <summary>
        /// Pulls order info based on ID number
        /// </summary>
        /// <param name="orderId">The ID of order in DB</param>
        /// <returns></returns>
        Task<Order?> GetOrderByIdAsync(int orderId);
        
    }
}

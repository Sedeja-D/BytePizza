using BytePizza.Models;

namespace BytePizza.Services
{
    /// <summary>
    /// Manages shopping cart state across pages (in-memory for now)
    /// This allows OrderBuilder to pass data to Checkout
    /// </summary>
    public class CartService
    {
        // ==================== CART DATA ====================

        /// <summary>Pizza configuration in cart</summary>
        public string PizzaSize { get; set; } = "";
        public string PizzaCrust { get; set; } = "";
        public string PizzaSauce { get; set; } = "";
        public List<string> PizzaToppings { get; set; } = new();
        public int PizzaQuantity { get; set; } = 0;
        public decimal PizzaPrice { get; set; } = 0m;

        /// <summary>Drink items in cart</summary>
        public class CartDrink
        {
            public string Name { get; set; } = "";
            public string Size { get; set; } = "";
            public int Quantity { get; set; } = 0;
            public decimal Price { get; set; } = 0m;
        }

        public List<CartDrink> Drinks { get; set; } = new();

        // ==================== METHODS ====================

        /// <summary>
        /// Checks if cart has any items
        /// </summary>
        public bool HasItems()
        {
            return PizzaQuantity > 0 || Drinks.Any(d => d.Quantity > 0);
        }

        /// <summary>
        /// Calculates cart subtotal
        /// </summary>
        public decimal GetSubtotal()
        {
            decimal pizzaTotal = PizzaPrice;
            decimal drinksTotal = Drinks.Sum(d => d.Price * d.Quantity);
            return pizzaTotal + drinksTotal;
        }

        /// <summary>
        /// Clears all cart data
        /// </summary>
        public void Clear()
        {
            PizzaSize = "";
            PizzaCrust = "";
            PizzaSauce = "";
            PizzaToppings.Clear();
            PizzaQuantity = 0;
            PizzaPrice = 0m;
            Drinks.Clear();
        }
    }
}
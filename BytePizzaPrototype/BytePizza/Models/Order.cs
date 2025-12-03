using BytePizza.Models;
using Microsoft.Web.WebView2.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BytePizza.Models
{
    ///<summary>
    ///Represents Order model
    ///</summary>
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public DateTime Orderdate { get; set; } = DateTime.Now;

        [Required]
        [StringLength(10)]
        public string OrderType { get; set; } = "Pickup";

        [Required]
        [StringLength(10)]
        public string OrderStatus { get; set; } = "Pending";

        [Required]
        [Column(TypeName = "decimal(10,2")]
        public decimal Subtotal { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2")]
        public decimal Tax { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2")]
        public decimal Total { get; set; }


        ///<summary>
        ///References the customer related to this order
        ///</summary>
        [ForeignKey("CustomerId")]
        public virtual Customer? Customer { get; set; }
        
        ///<summary>
        ///References the pizza selection related to this order
        ///</summary>
        public virtual PizzaOrder? Pizza { get; set; }
        
        ///<summary>
        ///References the drink selections related to this order
        ///</summary>
        public virtual ICollection<DrinkOrder> Drinks { get; set; } = new List<DrinkOrder>();

    }
}

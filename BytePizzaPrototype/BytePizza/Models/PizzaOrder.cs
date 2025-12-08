using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BytePizza.Models
{
    ///<summary>
    ///Represents pizza order with size, crust, sauce & toppings
    ///</summary>
    public class PizzaOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PizzaOrderId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        [StringLength(20)]
        public string PizzaSize { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Crust { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Sauce { get; set; } = string.Empty;

        /// <summary>
        /// Comma-separated list of toppings (e.g., "Pepperoni,Mushrooms,Onions")
        /// Increased to 200 chars to accommodate up to 4 toppings with long names
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Toppings { get; set; } = string.Empty;

        /// <summary>
        /// Number of this exact pizza configuration being ordered
        /// </summary>
        [Required]
        [Range(1, 99)]
        public int Quantity { get; set; } = 1;

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal PizzaOrderPrice { get; set; }

        ///<summary>
        ///References the order that contains this pizza selection
        ///</summary>
        [ForeignKey("OrderId")]
        public virtual Order? Order { get; set; }
    }
}
using BytePizza.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BytePizza.Models
{
    ///<summary>
    ///Represents drink order with type size and quantity
    ///</summary>
    public class DrinkOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DrinkOrderId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        [StringLength(15)]
        public string DrinkType { get; set; } = string.Empty;

        [Required]
        [StringLength(10)]
        public string DrinkSize { get; set; } = string.Empty;

        [Required]
        [Range(1, 99)]
        public int DrinkQuantity { get; set; } = 1;

        [Required]
        [Column(TypeName = "decimal(10,2")]
        public decimal DrinkOrderPrice { get; set; }

        ///<summary>
        ///References the order that contains this drink selection
        ///</summary>
        [ForeignKey("OrderId")]
        public virtual Order? Order { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BytePizza.Models
{
    ///<summary>
    ///Stores catalog of the restaurant menu items  
    ///</summary>
    public class MenuItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuItemId { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(15)]
        public string Category { get; set; } =  string.Empty;

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal MenuItemPrice { get; set; }
    }
}
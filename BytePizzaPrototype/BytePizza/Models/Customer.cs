using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BytePizza.Services.Implementations;

namespace BytePizza.Models 
{
    ///<summary>
    ///Represents customer account and authorization
    ///</summary>
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(10)]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [StringLength(15)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [StringLength(50)] 
        public string Name { get; set; } = String.Empty;

        [StringLength(200)]
        public string? Address { get; set; }

        public virtual ICollection<Order> Order { get; set; } = new List<Order>();
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesAutomationAPI.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative value.")]
        public int Quantity { get; set; }


        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Total Price must be a non-negative value.")]
        public decimal TotalPrice { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}

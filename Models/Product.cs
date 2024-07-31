using System.ComponentModel.DataAnnotations;
using SalesAutomationAPI.Data;

namespace SalesAutomationAPI.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        [ValidProductName]
        public string Name { get; set; }
        
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a non-negative value.")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Stock must be a non-negative value.")]
        public int Stock { get; set; }
    }
}

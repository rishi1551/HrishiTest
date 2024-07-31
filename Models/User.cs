using System.ComponentModel.DataAnnotations;
using SalesAutomationAPI.Data;
namespace SalesAutomationAPI.Models
{
    public class User
    {
       
        public int Id { get; set; }

        [Required]
        [ValidUsername]
        [MinLength(3)]
        public string Username { get; set; }

        [Required]
        [ValidPassword]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Authentication1.Models
{
    public class User
    {
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Key]
        public string Email { get; set; }

        public string Role { get; set; }
    }
}
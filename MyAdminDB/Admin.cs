
using System.ComponentModel.DataAnnotations;

namespace MyAdminDB
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }

}

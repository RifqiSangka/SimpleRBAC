using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimpleRBAC.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(100)]
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [Required]
        [MaxLength(100)]
        [DisplayName("Password")]
        public string Password { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}

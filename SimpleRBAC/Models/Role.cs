using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimpleRBAC.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        [MaxLength(100)]
        [DisplayName("Role Name")]
        public string RoleName { get; set; }
        [Required]
        [MaxLength(100)]
        [DisplayName("Role Description")]
        public string RoleDescription { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimpleRBAC.Models
{
    public class Permission
    {
        [Key]
        public int PermissionId { get; set; }
        [Required]
        [MaxLength(100)]
        [DisplayName("Permission Name")]
        public string PermissionName { get; set; }

        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}

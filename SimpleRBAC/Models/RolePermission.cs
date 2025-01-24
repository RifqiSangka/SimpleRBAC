﻿using System.ComponentModel.DataAnnotations;

namespace SimpleRBAC.Models
{
    public class RolePermission
    {
        [Key]
        public int RoleId { get; set; }
        public Role Role { get; set; }
        [Key]
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}

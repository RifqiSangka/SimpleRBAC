using Microsoft.EntityFrameworkCore;
using SimpleRBAC.Models;

namespace SimpleRBAC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<RolePermission>()
                .HasKey(rp => new { rp.RoleId, rp.PermissionId });

            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleId);

            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(rp => rp.PermissionId);

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    UserName = "admin",
                    Password = "admin"
                },
                new User
                {
                    UserId = 2,
                    UserName = "mid",
                    Password = "mid"
                },
                new User
                {
                    UserId = 3,
                    UserName = "normal",
                    Password = "normal"
                },
                new User
                {
                    UserId = 4,
                    UserName = "staff",
                    Password = "staff"
                }
            );
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    RoleId = 1,
                    RoleName = "Admin",
                    RoleDescription = "Admin Role"
                },
                new Role
                {
                    RoleId = 2,
                    RoleName = "Staff",
                    RoleDescription = "Can create and edit"
                },
                new Role
                {
                    RoleId = 3,
                    RoleName = "Viewer",
                    RoleDescription = "Can view only"
                },
                new Role
                {
                    RoleId = 4,
                    RoleName = "Executive",
                    RoleDescription = "Can approve and delete"
                }
            );
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    UserId = 1,
                    RoleId = 1
                },
                new UserRole
                {
                    UserId = 2,
                    RoleId = 2
                },
                new UserRole
                {
                    UserId = 2,
                    RoleId = 4
                },
                new UserRole
                {
                    UserId = 3,
                    RoleId = 3
                }

            );
            modelBuilder.Entity<Permission>().HasData(
                new Permission
                {
                    PermissionId = 1,
                    PermissionName = "View"
                },
                new Permission
                {
                    PermissionId = 2,
                    PermissionName = "Create"
                },
                new Permission
                {
                    PermissionId = 3,
                    PermissionName = "Edit"
                },
                new Permission
                {
                    PermissionId = 4,
                    PermissionName = "Approval"
                },
                new Permission
                {
                    PermissionId = 5,
                    PermissionName = "Delete"
                }
            );
            modelBuilder.Entity<RolePermission>().HasData(
                new RolePermission
                {
                    RoleId = 1,
                    PermissionId = 1
                },
                new RolePermission
                {
                    RoleId = 1,
                    PermissionId = 2
                },
                new RolePermission
                {
                    RoleId = 1,
                    PermissionId = 3
                },
                new RolePermission
                {
                    RoleId = 1,
                    PermissionId = 4
                },
                new RolePermission
                {
                    RoleId = 2,
                    PermissionId = 1
                },
                new RolePermission
                {
                    RoleId = 2,
                    PermissionId = 2
                },
                new RolePermission
                {
                    RoleId = 2,
                    PermissionId = 3
                },
                new RolePermission
                {
                    RoleId = 3,
                    PermissionId = 1
                },
                new RolePermission
                {
                    RoleId = 4,
                    PermissionId = 1
                },
                new RolePermission
                {
                    RoleId = 4,
                    PermissionId = 4
                },
                new RolePermission
                {
                    RoleId = 4,
                    PermissionId = 5
                }
            );
        }
    }
}

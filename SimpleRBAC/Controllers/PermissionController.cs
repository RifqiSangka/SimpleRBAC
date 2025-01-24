using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleRBAC.Data;

namespace SimpleRBAC.Controllers
{
    public class PermissionController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PermissionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> GetPermissions()
        {
            var permissions = await _context.Permissions
                .Include(p => p.RolePermissions)
                .ThenInclude(rp => rp.Role)
                .Select(p => new
                {
                    p.PermissionId,
                    p.PermissionName,
                    Roles = p.RolePermissions.Select(rp => rp.Role.RoleName)
                })
                .ToListAsync();
            return Ok(permissions);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> GetPermissionById(int id)
        {
            var permission = await _context.Permissions
                .Include(p => p.RolePermissions)
                .ThenInclude(rp => rp.Role)
                .Where(p => p.PermissionId == id)
                .Select(p => new
                {
                    p.PermissionId,
                    p.PermissionName,
                    Roles = p.RolePermissions.Select(rp => rp.Role.RoleName)
                })
                .FirstOrDefaultAsync();
            if (permission == null)
            {
                return NotFound();
            }
            return Ok(permission);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

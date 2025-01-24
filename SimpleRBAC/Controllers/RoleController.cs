using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleRBAC.Data;

namespace SimpleRBAC.Controllers
{
    public class RoleController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RoleController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _context.Roles
                .Include(r => r.UserRoles)
                .ThenInclude(ur => ur.User)
                .Select(r => new
                {
                    r.RoleId,
                    r.RoleName,
                    Users = r.UserRoles.Select(ur => ur.User.UserName)
                })
                .ToListAsync();
            return Ok(roles);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var role = await _context.Roles
                .Include(r => r.UserRoles)
                .ThenInclude(ur => ur.User)
                .Where(r => r.RoleId == id)
                .Select(r => new
                {
                    r.RoleId,
                    r.RoleName,
                    Users = r.UserRoles.Select(ur => ur.User.UserName)
                })
                .FirstOrDefaultAsync();
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }
    }
}

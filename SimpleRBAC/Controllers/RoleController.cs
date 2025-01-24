using Microsoft.AspNetCore.Mvc;

namespace SimpleRBAC.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

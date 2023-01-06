using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AHY.JWTApp.Mvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public string AdminPage()
        {
            return "AdminPage";
        }

        [Authorize(Roles = "Member")]
        public string MemberPage()
        {
            return "MemberPage";
        }
    }
}
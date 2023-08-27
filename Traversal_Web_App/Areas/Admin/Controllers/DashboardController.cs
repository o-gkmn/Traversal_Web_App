using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Web_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        Context c = new Context();

        public IActionResult Index()
        {
            ViewBag.v1 = c.Destinations.Count();
            ViewBag.v2 = c.Users.Count();
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Traversal_Web_App.Controllers
{
    public class InformationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

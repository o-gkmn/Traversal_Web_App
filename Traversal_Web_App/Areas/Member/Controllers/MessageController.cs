using Microsoft.AspNetCore.Mvc;

namespace Traversal_Web_App.Areas.Member.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

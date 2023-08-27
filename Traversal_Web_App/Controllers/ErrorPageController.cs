using Microsoft.AspNetCore.Mvc;

namespace Traversal_Web_App.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error404(int code)
        {

            return View();
        }
    }
}

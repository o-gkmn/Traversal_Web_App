using BusinnessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Web_App.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationManager;

        public DestinationController(IDestinationService destinationManager)
        {
            _destinationManager = destinationManager;
        }

        public IActionResult Index()
        {
            var values = _destinationManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult DestinationDetails(int id)
        {
            ViewBag.i = id;
            ViewBag.destID = id;
            var value = _destinationManager.TGetDestinationWithGuide(id);
            return View(value);
        }
    }
}

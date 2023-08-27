using BusinnessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Web_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            var values = _guideService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGuide(Guide guide)
        {
            _guideService.TAdd(guide);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditGuide()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditGuide(int id)
        {
            var values = _guideService.TGetById(id);
            _guideService.TUpdate(values);
            return RedirectToAction("Index");
        }


        public IActionResult ChangeToTrue(int id)
        {
            return RedirectToAction("Index");
        }
        public IActionResult ChangeToFalse(int id)
        {
            return RedirectToAction("Index");
        }

    }
}